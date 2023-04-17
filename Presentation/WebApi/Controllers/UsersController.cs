using Application.Abstractions.Storage;
using Application.Abstractions.Storage.Local;
using Application.Features.Command.User.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStorageService _storageService;
        public UsersController(IMediator mediator, IStorageService storageService)
        {
            _mediator = mediator;
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {
            var res = await _storageService.UploadAsync("uploads/image", Request.Form.Files);
            return Ok(res);
        }

    }
}
