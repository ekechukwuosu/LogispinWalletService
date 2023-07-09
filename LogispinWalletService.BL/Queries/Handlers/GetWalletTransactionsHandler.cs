using AutoMapper;
using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.Common.Static;
using LogispinWalletService.DAL.Repository.Interfaces;
using MediatR;
using Transaction = LogispinWalletService.Data.Models.Transaction;
using TransactionStatus = LogispinWalletService.Common.Enums.TransactionStatus;

namespace LogispinWalletService.BL.Queries.Handlers
{
    public class GetWalletTransactionsHandler : IRequestHandler<GetWalletTransactionsQuery, ServiceResponse<GetWalletTransactionsResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public GetWalletTransactionsHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetWalletTransactionsResponse>> Handle(GetWalletTransactionsQuery request, CancellationToken cancellationToken)
        {
          
            List<WalletTransaction> walletTransactions = new List<WalletTransaction>();
            var getWalletTransactionRequest = request.GetWalletTransactionsRequest;
            var isAccountValid = await _accountRepository.CheckIfAccountExists(getWalletTransactionRequest.Email);
            var getAll = getWalletTransactionRequest.TransactionStatus == Common.Enums.TransactionQueryStatus.All;
            var message = ResponseMessages.SuccessKey;
            if (isAccountValid)
            {
                var accountId = await _accountRepository.GetAccountId(getWalletTransactionRequest.Email);
                var transactions = new List<Transaction>();
                if (getAll)
                {
                    transactions  = await _transactionRepository.GetTransactions(accountId, getWalletTransactionRequest.PageNumber, getWalletTransactionRequest.PageSize);
                }
                else
                {
                    var status = (TransactionStatus)getWalletTransactionRequest.TransactionStatus;
                    transactions = await _transactionRepository.GetTransactionsByAccountIdAndStatus(accountId, status, getAll, getWalletTransactionRequest.PageNumber, getWalletTransactionRequest.PageSize);
                }
                walletTransactions = _mapper.Map<List<Transaction>, List<WalletTransaction>>(transactions);
                
            }
            return new ServiceResponse<GetWalletTransactionsResponse>() { Data = new GetWalletTransactionsResponse(walletTransactions), ResponseMessage = message };
        }
    }
}
