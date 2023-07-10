using LogispinWalletService.Data.DB;
using LogispinWalletService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LogspinWalletService.Tests.Utility.FakeDBContexts
{
    public class FakeDBContexts
    {
        public async Task<AppDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDBContext(options);
            databaseContext.Database.EnsureCreated();
            if (databaseContext.Accounts.Count() <= 0)
            {
                databaseContext.Accounts.Add(new Account()
                {
                    CurrentBalance = 1000,
                    FirstName = "Ekechukwu",
                    LastName = "Osu",
                    Email = "ekechukwuosu@hotmail.com",
                    Status = LogispinWalletService.Common.Enums.AccountStatus.Active,
                    DateCreated = new DateTime(2023,07,10),
                    DateUpdated = new DateTime(2023, 07, 10),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1")
                });
                await databaseContext.SaveChangesAsync();

            }
            if (databaseContext.Transactions.Count() <= 0)
            {
                databaseContext.Transactions.Add(new Transaction()
                {
                    AccountId = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1"),
                    Amount = 2500,
                    IsAmountGreaterThanBalance = false,
                    Type = LogispinWalletService.Common.Enums.TransactionType.Add,
                    Status = LogispinWalletService.Common.Enums.TransactionStatus.Success,
                    DateCreated = new DateTime(2023, 07, 10),
                    DateUpdated = new DateTime(2023, 07, 10),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B2")
                });
                databaseContext.Transactions.Add(new Transaction()
                {
                    AccountId = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1"),
                    Amount = 1500,
                    IsAmountGreaterThanBalance = false,
                    Type = LogispinWalletService.Common.Enums.TransactionType.Remove,
                    Status = LogispinWalletService.Common.Enums.TransactionStatus.Failed,
                    DateCreated = new DateTime(2023, 07, 09),
                    DateUpdated = new DateTime(2023, 07, 09),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B3")
                });
                await databaseContext.SaveChangesAsync();

            }
            return databaseContext;
        }
    }
}
