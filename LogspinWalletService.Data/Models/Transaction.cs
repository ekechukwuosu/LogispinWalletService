using LogispinWalletService.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace LogispinWalletService.Data.Models
{
    [Index(nameof(AccountId))]
    [Index(nameof(AccountId), nameof(Status))]
    public class Transaction: Entity
    {
        public Guid AccountId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public bool IsAmountGreaterThanBalance { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }

    }
}
