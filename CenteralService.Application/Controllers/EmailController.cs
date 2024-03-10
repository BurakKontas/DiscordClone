using CenteralService.Application.Queries;
using CenteralService.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CenteralService.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("sendaccountverificationemail")]
        public async Task<IActionResult> SendAccountVerificationEmail([FromBody] AccountVerificationEmailRequest request)
        {
            var reply = await _mediator.Send(new SendAccountVerificationEmailQuery(request));
            return Ok(reply);
        }

        [HttpPost("sendcustomemail")]
        public async Task<IActionResult> SendCustomEmail([FromBody] CustomEmailRequest request)
        {
            var reply = await _mediator.Send(new SendCustomEmailQuery(request));
            return Ok(reply);
        }

        [HttpPost("sendresetpasswordemail")]
        public async Task<IActionResult> SendResetPasswordEmail([FromBody] ResetPasswordEmailRequest request)
        {
            var reply = await _mediator.Send(new SendResetPasswordEmailQuery(request));
            return Ok(reply);
        }
    }
}
