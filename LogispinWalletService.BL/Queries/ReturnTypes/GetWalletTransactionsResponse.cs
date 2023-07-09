using System.Transactions;

namespace LogispinWalletService.BL.Queries.ReturnTypes
{
    public record GetWalletTransactionsResponse(List<WalletTransaction> WalletTransactions);
    public class WalletTransaction 
    {
        public decimal amount { get; set; }
        public string transactionStatus { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }
    }
}