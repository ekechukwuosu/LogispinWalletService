using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.BL.Queries.ReturnTypes
{
    public record GetWalletDetailsResponse(string firstName, string lastName, string email, decimal currentBalance, AccountStatus AccountStatus, DateTime DateCreated);
}
