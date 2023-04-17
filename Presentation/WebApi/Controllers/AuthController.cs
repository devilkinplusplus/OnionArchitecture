using Application.Features.Command.Authentication.Login;
using Application.Features.Command.Authentication.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            LoginCommandResponse res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshLogin(RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
