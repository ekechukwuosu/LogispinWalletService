using LogispinWalletService.Common.Enums;
using LogispinWalletService.Data.Models;

namespace LogispinWalletService.DAL.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> LogTransaction(Guid accountId, decimal  amount, TransactionType transactionType);
        Task<List<Transaction>> GetTransactions(Guid accountId, int pageNumber, int pageSize);
        Task<List<Transaction>> GetTransactionsByAccountIdAndStatus(Guid accountId, TransactionStatus? transactionStatus, bool getAll, int pageNumber, int pageSize);
        Task<int> GetPendingTransactionsCount(Guid accountId);
        Task<int> GetSuccessfulTransactionsCount(Guid accountId);
        Task<int> GetFailedTransactionsCount(Guid accountId);
        void ProcessPendingTransactions(Guid transactionId);
    }
}
