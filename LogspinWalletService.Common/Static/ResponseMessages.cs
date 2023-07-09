namespace LogispinWalletService.Common.Static
{
    public static class ResponseMessages
    {
        public const string SuccessKey = "Success";
        public const string FailedKey = "Failed";
        public const string AccountSuccessKey = "Account creation successful";
        public const string AccountFailureKey = "Account creation failed";
        public const string InvalidAccountKey = "Account does not exist";
        public const string AccountExistsKey = "An Account with this email already exist. This account request cannot be fulfilled";
        public const string TransactionSuccessKey = "Transaction request logged successfully with Pending Status";
        public const string TransactionFailureKey = "Transaction request was logged with Failed status";
        public const string AmountGreaterThanBalanceKey = "The transaction amount is greater than the current balance";
    }
}
