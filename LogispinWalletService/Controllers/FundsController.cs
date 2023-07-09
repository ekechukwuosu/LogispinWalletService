using LogispinWalletService.BL.Commands;
using LogispinWalletService.BL.Commands.RequestTypes;
using LogispinWalletService.BL.Helper;
using LogispinWalletService.BL.Queries;
using LogispinWalletService.BL.Queries.RequestTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogispinWalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FundsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetWalletTransactionSummary")]
        public async Task<ActionResult> GetSummary([FromQuery] GetWalletDetailsRequest getWalletDetailsRequest)
        {
            if (!RequestValidationHelper.ValidateGetWalletDetailsRequest(getWalletDetailsRequest))
            {
                return BadRequest("Invalid input parameters");
            }
            GetWalletTransactionStatusSummaryQuery walletTransactionStatusSummaryQuery = new(new GetWalletDetailsRequest() { Email = getWalletDetailsRequest.Email });

            var response = await _mediator.Send(walletTransactionStatusSummaryQuery);
            return Ok(response);
        }
        [HttpPost("AddFunds")]
        public async Task<ActionResult> Add([FromBody] FundsRequest fundsRequest)
        {
            if (!RequestValidationHelper.ValidateFundsRequest(fundsRequest))
            {
                return BadRequest("Invalid input parameters");
            }
            LogTransactionCommand logTransactionCommand = new(new LogTransactionRequest() { Email = fundsRequest.Email, Amount = fundsRequest.Amount, Type = Common.Enums.TransactionType.Add });

            var response = await _mediator.Send(logTransactionCommand);
            return Ok(response);
        }
        [HttpPost("RemoveFunds")]
        public async Task<ActionResult> Remove([FromBody] FundsRequest fundsRequest)
        {
            if (!RequestValidationHelper.ValidateFundsRequest(fundsRequest))
            {
                return BadRequest("Invalid input parameters");
            }
            LogTransactionCommand logTransactionCommand = new(new LogTransactionRequest() { Email = fundsRequest.Email, Amount = fundsRequest.Amount, Type = Common.Enums.TransactionType.Remove });

            var response = await _mediator.Send(logTransactionCommand);
            return Ok(response);
        }
    }
}
