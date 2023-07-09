using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Commands.ReturnTypes;
using LogispinWalletService.Common.Static;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.Models;
using MediatR;

namespace LogispinWalletService.BL.Commands.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ServiceResponse<CreateAccountResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ServiceResponse<CreateAccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var createAccountRequest = request.CreateAccountRequest;
            Account response = new Account();
            string message = string.Empty;
            if (! await _accountRepository.CheckIfAccountExists(createAccountRequest.Email))
            {
                response = await _accountRepository.CreateAccount(createAccountRequest.FirstName, createAccountRequest.LastName, createAccountRequest.Email);
                message = response.DateCreated != DateTime.MinValue ? ResponseMessages.SuccessKey : ResponseMessages.SuccessKey;
            }
            else
            {
                message = ResponseMessages.AccountExistsKey;
            }
            return new ServiceResponse<CreateAccountResponse>() { Data = new CreateAccountResponse(response.FirstName, response.LastName, response.Email, response.DateCreated), ResponseMessage = message};
        }
    }
}
