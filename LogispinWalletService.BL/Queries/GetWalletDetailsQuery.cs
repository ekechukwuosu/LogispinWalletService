using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Queries.RequestTypes;
using LogispinWalletService.BL.Queries.ReturnTypes;
using MediatR;

namespace LogispinWalletService.BL.Queries
{
    public record GetWalletDetailsQuery(GetWalletDetailsRequest GetWalletDetailsRequest) : IRequest<ServiceResponse<GetWalletDetailsResponse>>;
}
