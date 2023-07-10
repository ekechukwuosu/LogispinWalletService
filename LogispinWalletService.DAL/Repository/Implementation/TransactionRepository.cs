using LogispinWalletService.Common.Enums;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.DB;
using LogispinWalletService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LogispinWalletService.DAL.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDBContext _dB;
        private readonly ILogger<TransactionRepository> _logger;
        public TransactionRepository(AppDBContext dB, ILogger<TransactionRepository> logger) 
        {
            _dB = dB;
            _logger = logger;
        }

        public async Task<int> GetFailedTransactionsCount(Guid accountId)
        {
            var failedTransactions = await _dB.Transactions.Where(a => a.AccountId.Equals(accountId) && a.Status.Equals(TransactionStatus.Failed)).ToListAsync();
            return failedTransactions.Count();
        }

        public async Task<int> GetPendingTransactionsCount(Guid accountId)
        {
            var pendingTransactions = await _dB.Transactions.Where(a => a.AccountId.Equals(accountId) && a.Status.Equals(TransactionStatus.Pending)).ToListAsync();
            return pendingTransactions.Count();
        }

        public async Task<int> GetSuccessfulTransactionsCount(Guid accountId)
        {
            var successfulTransactions = await _dB.Transactions.Where(a => a.AccountId.Equals(accountId) && a.Status.Equals(TransactionStatus.Success)).ToListAsync();
            return successfulTransactions.Count();
        }

        public async Task<List<Transaction>> GetTransactions(Guid accountId, int pageNumber, int pageSize)
        {
            return await _dB.Transactions.Where(a => a.AccountId.Equals(accountId))
                    .OrderByDescending(a => a.DateCreated)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByAccountIdAndStatus(Guid accountId, TransactionStatus? transactionStatus, bool getAll, int pageNumber, int pageSize)
        {
            List<Transaction> result = new List<Transaction>();
            if (getAll)
            {
                result = await _dB.Transactions.Where(a => a.AccountId.Equals(accountId))
                        .OrderByDescending(a => a.DateCreated)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize).ToListAsync();
            }
            else
            {
                result = await _dB.Transactions.Where(a => a.AccountId.Equals(accountId) && a.Status.Equals(transactionStatus))
                        .OrderByDescending(a => a.DateCreated)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize).ToListAsync();
            }
            return result;
        }

        public async Task<Transaction> LogTransaction(Guid accountId, decimal amount, TransactionType transactionType)
        {
            // Composing transaction request to be passed to DB
            var transaction = new Transaction()
            {
                AccountId = accountId,
                Amount = amount,
                Type = transactionType,
                Status = TransactionStatus.Pending
                

            };
            try
            {     
                //Persisiting transaction request
                await _dB.Transactions.AddAsync(transaction);
                _dB.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AccountRepository class, CreateAccount Method. Message : {ex.Message}");
            }
            return transaction;
        }

        public void ProcessPendingTransactions(Guid transactionId)
        {
            bool action = false;
            var transaction = _dB.Transactions.FirstOrDefault(a => a.Id.Equals(transactionId));
            if (transaction != null)
            {
                var account = _dB.Accounts.FirstOrDefault(a => a.Id.Equals(transaction.AccountId));
                if (account != null)
                {
                    if (transaction.Type == TransactionType.Add)
                    {
                        account.CurrentBalance += transaction.Amount;
                        action = true;
                    }
                    else if (transaction.Type == TransactionType.Remove && account.CurrentBalance >= transaction.Amount)
                    {
                        account.CurrentBalance -= transaction.Amount;
                        action = true;
                    }

                    if (action)
                    {
                        account.DateUpdated = DateTime.Now;
                        transaction.Status = TransactionStatus.Success;
                        transaction.DateUpdated = DateTime.Now;

                    }
                    else
                    {
                        transaction.IsAmountGreaterThanBalance = true;
                        transaction.Status = TransactionStatus.Failed;
                    }

                    _dB.Accounts.Update(account);
                    _dB.Transactions.Update(transaction);
                    _dB.SaveChanges();
                }
            }                   
        }
    }
}
