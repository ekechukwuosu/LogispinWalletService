using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Commands.ReturnTypes;
using MediatR;

namespace LogispinWalletService.BL.Commands
{
    public record CreateAccountCommand (CreateAccountRequest CreateAccountRequest) : IRequest<ServiceResponse<CreateAccountResponse>>;
}
