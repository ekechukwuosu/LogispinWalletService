namespace LogispinWalletService.BL.Queries.ReturnTypes
{
    public record GetWalletDetailsResponse(string firstName, string lastName, string email, decimal currentBalance, string AccountStatus, DateTime DateCreated);
}
