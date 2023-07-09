namespace LogispinWalletService.BL.Queries.ReturnTypes
{
    public record GetWalletTransactionStatusSummaryResponse(string pending, string success, string failed);
}
