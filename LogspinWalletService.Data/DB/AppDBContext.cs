using LogispinWalletService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LogispinWalletService.Data.DB
{
    public class AppDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
    }
}
