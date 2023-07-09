using LogispinWalletService.Common.Enums;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.DB;
using LogispinWalletService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LogispinWalletService.DAL.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext _dB;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(AppDBContext dB, ILogger<AccountRepository> logger)
        {
            _dB = dB;
            _logger = logger;
        }

        public async Task<bool> CheckIfAccountExists(string email)
        {
            return await _dB.Accounts.AnyAsync(a => a.Email.Equals(email));
        }

        public async Task<Account> CreateAccount(string firstName, string lastName, string email)
        {
           var account =  new Account() { FirstName = firstName, LastName = lastName, Email = email, Status = AccountStatus.Active};
            try
            {
                //Persisiting account request
                await _dB.Accounts.AddAsync(account);
                _dB.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AccountRepository class, CreateAccount Method. Message : {ex.Message}");
            }            

            //Return the ID of newly created account
            return account;
        }

        public async Task<Account> GetAccountDetailsWithAccountId(Guid accountId)
        {
            Account account = new Account();
            try
            {
                account = await _dB.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(accountId));
            }catch (Exception ex)
            {
                _logger.LogError($"Error in AccountRepository class, GetAccountDetails Method. Message : {ex.Message}");
            }
            return account ?? new Account();
        }

        public async Task<Account> GetAccountDetailsWithEmail(string email)
        {
            return await _dB.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
        }

        public async Task<Guid> GetAccountId(string email)
        {
            var account =  await _dB.Accounts.FirstOrDefaultAsync(b => b.Email.Equals(email));
            return account.Id;
        }
    }
}
