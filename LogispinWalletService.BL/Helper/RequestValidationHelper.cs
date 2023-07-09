using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Queries.RequestTypes;
using LogispinWalletService.Common.Helper;

namespace LogispinWalletService.BL.Helper
{
    public static class RequestValidationHelper
    {
        public static bool ValidateFundsRequest (FundsRequest fundsRequest)
        {
            if (fundsRequest == null || string.IsNullOrEmpty(fundsRequest.Email) || !EmailValidationHelper.IsValidEmail(fundsRequest.Email) || fundsRequest.Amount <= 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateCreateAccountRequest(CreateAccountRequest createAccountRequest)
        {
            if (createAccountRequest == null || string.IsNullOrEmpty(createAccountRequest.FirstName) || string.IsNullOrEmpty(createAccountRequest.LastName) || string.IsNullOrEmpty(createAccountRequest.Email) || !EmailValidationHelper.IsValidEmail(createAccountRequest.Email))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetWalletDetailsRequest (GetWalletDetailsRequest getWalletDetailsRequest)
        {
            if (getWalletDetailsRequest == null || (string.IsNullOrEmpty(getWalletDetailsRequest.Email) && !EmailValidationHelper.IsValidEmail(getWalletDetailsRequest.Email)))
            {
                return false;
            }
            return true;
        }
    }
}
