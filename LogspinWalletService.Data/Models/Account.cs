using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.Data.Models
{
    public class Account : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AccountStatus Status { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        
    }
}
