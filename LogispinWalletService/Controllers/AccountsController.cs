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
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetWalletDetails")]
        public async Task<ActionResult> Get([FromQuery] GetWalletDetailsRequest getWalletDetailsRequest)
        {
            if (!RequestValidationHelper.ValidateGetWalletDetailsRequest(getWalletDetailsRequest))
            {
                return BadRequest("Invalid input parameters");
            }
            GetWalletDetailsQuery getWalletDetailsQuery = new(getWalletDetailsRequest);

            var response = await _mediator.Send(getWalletDetailsQuery);
            return Ok(response);
        }
        [HttpPost("CreateWalletAccount")]
        public async Task<ActionResult> Create([FromBody] CreateAccountRequest createAccountRequest)
        {
            if (!RequestValidationHelper.ValidateCreateAccountRequest(createAccountRequest))
            {
                return BadRequest("Invalid input parameters");
            }
            CreateAccountCommand createAccountCommand = new(createAccountRequest);


            var response = await _mediator.Send(createAccountCommand);
            return Ok(response);
        }
    }
}
