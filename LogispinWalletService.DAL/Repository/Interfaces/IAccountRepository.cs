using LogispinWalletService.Data.Models;

namespace LogispinWalletService.DAL.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> CreateAccount (string firstName, string lastName, string email);
        Task<Account> GetAccountDetailsWithAccountId(Guid accountId);
        Task<Account> GetAccountDetailsWithEmail(string email);
        Task<Guid> GetAccountId(string email); 
        Task<bool> CheckIfAccountExists(string email);
    }
}
