using Hangfire;
using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Commands.ReturnTypes;
using LogispinWalletService.Common.Static;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.Models;
using MediatR;

namespace LogispinWalletService.BL.Commands.Handlers
{
    public class LogTransactionHandler : IRequestHandler<LogTransactionCommand, ServiceResponse<LogTransactionResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public LogTransactionHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository, IBackgroundJobClient backgroundJobClient)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _backgroundJobClient = backgroundJobClient;
        }
        public async Task<ServiceResponse<LogTransactionResponse>> Handle(LogTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction response = new Transaction();
            var processFundstRequest = request.ProcessFundsRequest;
            var accountId = _accountRepository.GetAccountId(processFundstRequest.Email).Result;
            var account = await _accountRepository.GetAccountDetailsWithAccountId(accountId);
            string message = ResponseMessages.TransactionSuccessKey;

            if (account != null)
            {
               response = await _transactionRepository.LogTransaction(accountId, processFundstRequest.Amount, processFundstRequest.Type);
                _backgroundJobClient.Enqueue(() => _transactionRepository.ProcessPendingTransactions(response.Id));
            }
            else
            {
                message = ResponseMessages.InvalidAccountKey;
            }
            return new ServiceResponse<LogTransactionResponse>() { Data = new LogTransactionResponse(response.AccountId, response.Amount, response.Status, response.DateCreated), ResponseMessage = message } ;
        }
    }
}
