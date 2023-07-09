using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.BL.Commands.RequestTypes
{
    public class LogTransactionRequest
    {
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
