using Conversation.Common.ViewModels.Queries;
using Conversation.Common.ViewModels.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conversation.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            var response =await _mediator.Send(loginUserCommand);
            return Ok(response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateUserCommand updateUserCommand)
        {
            var response = await _mediator.Send(updateUserCommand);
            return Ok(response);
        }

    }
}
