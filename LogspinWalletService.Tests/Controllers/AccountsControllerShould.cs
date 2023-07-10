using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Commands;
using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Commands.ReturnTypes;
using LogispinWalletService.BL.Queries;
using LogispinWalletService.BL.Queries.RequestTypes;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.Controllers;
using LogspinWalletService.Tests.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LogspinWalletService.Tests.Controllers
{
    public class AccountsControllerShould
    {
        private readonly AccountsController _accountsController;
        private Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        public AccountsControllerShould()
        {            
            _accountsController = new AccountsController(_mockIMediator.Object);
        }
        [Fact]
        public void CreateAccount_Should_return_BadRequest()
        {
            var request = new CreateAccountRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<CreateAccountCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<CreateAccountResponse>());
            
            var result = _accountsController.Create(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void CreateAccount_Should_return_Ok_Success()
        {
            var request = TestRequestParameters.GetSampleCreateAccountRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<CreateAccountCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<CreateAccountResponse>());

            var result = _accountsController.Create(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetAccountDetails_Should_return_BadRequest()
        {
            var request = new GetWalletDetailsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletDetailsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletDetailsResponse>());

            var result = _accountsController.Get(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void GetAccountDetails_Should_return_Ok_Success()
        {
            var request = TestRequestParameters.GetSampleGetWalletAccountDetailsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletDetailsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletDetailsResponse>());

            var result = _accountsController.Get(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }
    }
}
