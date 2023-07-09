namespace LogispinWalletService.BL.Commands.ReturnTypes
{
    public record CreateAccountResponse(string firstName, string lastName, string email, DateTime dateCreated);
}
