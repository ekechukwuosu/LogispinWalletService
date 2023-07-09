using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.DAL.Responses
{
    public class TransactionResponse
    {
        public TransactionStatus Status { get; set; }
        public string Reason { get; set; }
    }
}
