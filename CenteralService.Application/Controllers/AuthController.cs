using CenteralService.Application.Queries;
using CenteralService.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CenteralService.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("validatetoken")]
        public async Task<IActionResult> ValidateToken([FromBody] TokenValidationRequest request)
        {
            var reply = await _mediator.Send(new ValidateTokenQuery(request));
            return Ok(reply);
        }

        [HttpPost("banuser")]
        public async Task<IActionResult> BanUser([FromBody] BanUserRequest request)
        {
            var reply = await _mediator.Send(new BanUserQuery(request));
            return Ok(reply);
        }

        [HttpPost("unbanuser")]
        public async Task<IActionResult> UnbanUser([FromBody] UnbanUserRequest request)
        {
            var reply = await _mediator.Send(new UnbanUserQuery(request));
            return Ok(reply);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var reply = await _mediator.Send(new RegisterQuery(request));
            return Ok(reply);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var reply = await _mediator.Send(new LoginQuery(request));
            return Ok(reply);
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var reply = await _mediator.Send(new ForgotPasswordQuery(request));
            return Ok(reply);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var reply = await _mediator.Send(new RefreshTokenQuery(request));
            return Ok(reply);
        }

        [HttpPost("extracttoken")]
        public async Task<IActionResult> ExtractToken([FromBody] ExtractTokenRequest request)
        {
            var reply = await _mediator.Send(new ExtractTokenQuery(request));
            return Ok(reply);
        }


    }
}
