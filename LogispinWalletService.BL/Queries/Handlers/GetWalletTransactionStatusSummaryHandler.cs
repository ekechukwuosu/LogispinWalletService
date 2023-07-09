using Azure;
using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.Common.Static;
using LogispinWalletService.DAL.Repository.Interfaces;
using MediatR;

namespace LogispinWalletService.BL.Queries.Handlers
{
    public class GetWalletTransactionStatusSummaryHandler : IRequestHandler<GetWalletTransactionStatusSummaryQuery, ServiceResponse<GetWalletTransactionStatusSummaryResponse>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public GetWalletTransactionStatusSummaryHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<ServiceResponse<GetWalletTransactionStatusSummaryResponse>> Handle(GetWalletTransactionStatusSummaryQuery request, CancellationToken cancellationToken)
        {
            var getWalletDetailsRequest = request.GetWalletDetailsRequest;
            var accountId = await _accountRepository.GetAccountId(getWalletDetailsRequest.Email);

            var pendingTransactions = await _transactionRepository.GetPendingTransactionsCount(accountId);
            var failedTransactions = await _transactionRepository.GetFailedTransactionsCount(accountId);
            var SuccessfulTransactions = await _transactionRepository.GetSuccessfulTransactionsCount(accountId);
            string message = ResponseMessages.SuccessKey;

            return new ServiceResponse<GetWalletTransactionStatusSummaryResponse>() { Data = new GetWalletTransactionStatusSummaryResponse(pendingTransactions.ToString(), SuccessfulTransactions.ToString(), failedTransactions.ToString()), ResponseMessage = message };
        }
    }
}
