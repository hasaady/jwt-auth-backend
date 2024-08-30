using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Authentication.Application.Features.Login;
using Authentication.Application.Features.RefreshToken;
using Authentication.Application.Features.RegisterUser;
using Microsoft.AspNetCore.Authorization;
using Authentication.API.Controllers.Base;

namespace Authentication.Controllers
{
    [Route("authentication")]
    public class AuthenticateController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _mediator.Send(command);
        }

        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize]
        [HttpPost("refresh")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenCommand command)
        {

            var accessToken = Request.Headers[HeaderNames.Authorization]
                .ToString()
                .Substring("Bearer ".Length)
                .Trim();

            command.AccessToken = accessToken;

            return await _mediator.Send(command);
        }
    }
}
