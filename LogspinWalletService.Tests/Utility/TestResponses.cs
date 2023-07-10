using LogispinWalletService.Data.Models;

namespace LogspinWalletService.Tests.Utility
{
    public class TestResponses
    {
        public static Account GetSampleAccount()
        {
            return new Account
            {
                CurrentBalance = 1000,
                FirstName = "Ekechukwu",
                LastName = "Osu",
                Email = "ekechukwuosu@hotmail.com",
                Status = LogispinWalletService.Common.Enums.AccountStatus.Active,
                DateCreated = new DateTime(2023, 07, 10),
                DateUpdated = new DateTime(2023, 07, 10),
                Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1")
            };
        }
        public static List<Transaction> GetSampleSingleTransactionInList()
        {
            return new List<Transaction>()
            {
                new Transaction
                {
                    AccountId = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1"),
                    Amount = 2500,
                    IsAmountGreaterThanBalance = false,
                    Type = LogispinWalletService.Common.Enums.TransactionType.Add,
                    Status = LogispinWalletService.Common.Enums.TransactionStatus.Success,
                    DateCreated = new DateTime(2023, 07, 10),
                    DateUpdated = new DateTime(2023, 07, 10),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B2")
                }
            };
        }
        public static List<Transaction> GetSampleTransactionList()
        {
            return new List<Transaction>()
            {
                new Transaction
                {
                    AccountId = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1"),
                    Amount = 2500,
                    IsAmountGreaterThanBalance = false,
                    Type = LogispinWalletService.Common.Enums.TransactionType.Add,
                    Status = LogispinWalletService.Common.Enums.TransactionStatus.Success,
                    DateCreated = new DateTime(2023, 07, 10),
                    DateUpdated = new DateTime(2023, 07, 10),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B2")
                },
                new Transaction()
                {
                    AccountId = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B1"),
                    Amount = 1500,
                    IsAmountGreaterThanBalance = false,
                    Type = LogispinWalletService.Common.Enums.TransactionType.Remove,
                    Status = LogispinWalletService.Common.Enums.TransactionStatus.Failed,
                    DateCreated = new DateTime(2023, 07, 09),
                    DateUpdated = new DateTime(2023, 07, 09),
                    Id = new Guid("2CD79108-1CE8-4351-1FC5-08D9E62605B3")
                }
            };
        }
    }
}
