using LogispinWalletService.Common.Enums;

namespace LogispinWalletService.BL.Commands.ReturnTypes
{
    public record LogTransactionResponse(Guid accountId, decimal amount, TransactionStatus TransactionStatus, DateTime DateCreated);
}
