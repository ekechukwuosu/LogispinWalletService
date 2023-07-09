using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Helper;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.Common.Static;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.Models;
using MediatR;

namespace LogispinWalletService.BL.Queries.Handlers
{
    public class GetWalletDetailsHandler : IRequestHandler<GetWalletDetailsQuery, ServiceResponse<GetWalletDetailsResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        public GetWalletDetailsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ServiceResponse<GetWalletDetailsResponse>> Handle(GetWalletDetailsQuery request, CancellationToken cancellationToken)
        {
            Account response = new Account();
            var getWalletDetailsRequest = request.GetWalletDetailsRequest;
            response = await _accountRepository.GetAccountDetailsWithEmail(getWalletDetailsRequest.Email);
            string message = response != null? ResponseMessages.SuccessKey : ResponseMessages.InvalidAccountKey;

            return new ServiceResponse<GetWalletDetailsResponse>() { Data = new GetWalletDetailsResponse(response.FirstName, response.LastName, response.Email, response.CurrentBalance, UtilityHelper.GetEnumDescription(response.Status), response.DateCreated), ResponseMessage = message };
            
        }
    }
}
