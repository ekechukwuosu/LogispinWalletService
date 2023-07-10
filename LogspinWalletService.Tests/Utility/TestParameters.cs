using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Queries.RequestTypes;
using LogispinWalletService.Common.Enums;

namespace LogspinWalletService.Tests.Utility
{
    public class TestParameters
    {
        public static CreateAccountRequest GetSampleCreateAccountRequest()
        {
            return new CreateAccountRequest
            {
                FirstName = "Ekechukwu",
                LastName = "Osu",
                Email = "ekechukwuosu@hotmail.com"
            };
        }
        public static GetWalletDetailsRequest GetSampleGetWalletAccountDetailsRequest()
        {
            return new GetWalletDetailsRequest
            {
                Email = "ekechukwuosu@hotmail.com"
            };
        }
        public static FundsRequest GetSampleFundsRequest()
        {
            return new FundsRequest
            {
                Email = "ekechukwuosu@hotmail.com",
                Amount = 1000                
            };
        }
        public static GetWalletTransactionsRequest GetSampleGetWalletTransactionsRequest()
        {
            return new GetWalletTransactionsRequest
            {
                Email = "ekechukwuosu@hotmail.com",
                PageNumber = 1,
                PageSize = 10,
                TransactionStatus = TransactionQueryStatus.Success,
            };
        }
    }
}

