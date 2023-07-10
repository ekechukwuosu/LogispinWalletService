using LogispinWalletService.BL.APIResponse;
using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Commands.ReturnTypes;
using LogispinWalletService.BL.Commands;
using LogispinWalletService.Controllers;
using LogspinWalletService.Tests.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using LogispinWalletService.BL.Queries.RequestTypes;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.BL.Queries;

namespace LogspinWalletService.Tests.Controllers
{
    public class FundsControllerShould
    {
        private readonly FundsController _fundsController;
        private Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        public FundsControllerShould()
        {
            _fundsController = new FundsController(_mockIMediator.Object);
        }
        [Fact]
        public void AddFunds_Should_return_BadRequest()
        {
            var request = new FundsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<LogTransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<LogTransactionResponse>());

            var result = _fundsController.Add(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void RemoveFunds_Should_return_BadRequest()
        {
            var request = new FundsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<LogTransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<LogTransactionResponse>());

            var result = _fundsController.Remove(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void AddFunds_Should_return_Ok_Success()
        {
            var request = TestParameters.GetSampleFundsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<LogTransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<LogTransactionResponse>());

            var result = _fundsController.Add(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }
        [Fact]
        public void RemoveFunds_Should_return_Ok_Success()
        {
            var request = TestParameters.GetSampleFundsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<LogTransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<LogTransactionResponse>());

            var result = _fundsController.Remove(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetWalletTransactionDetailsSummary_Should_return_BadRequest()
        {
            var request = new GetWalletDetailsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletTransactionStatusSummaryQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletTransactionStatusSummaryResponse>());

            var result = _fundsController.GetSummary(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void GetWalletTransactionDetailsSummary_Should_return_Ok_Success()
        {
            var request = TestParameters.GetSampleGetWalletAccountDetailsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletTransactionStatusSummaryQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletTransactionStatusSummaryResponse>());

            var result = _fundsController.GetSummary(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetTransactions_Should_return_BadRequest()
        {
            var request = new GetWalletTransactionsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletTransactionsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletTransactionsResponse>());

            var result = _fundsController.GetTransactions(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }
        [Fact]
        public void GetTransactions_Should_return_Ok_Success()
        {
            var request = TestParameters.GetSampleGetWalletTransactionsRequest();

            _mockIMediator.Setup(s => s.Send(It.IsAny<GetWalletTransactionsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ServiceResponse<GetWalletTransactionsResponse>());

            var result = _fundsController.GetTransactions(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        }
    }
}
