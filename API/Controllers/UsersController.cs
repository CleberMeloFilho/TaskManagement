using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.Users;
using TaskManagement.Application.Queries.Users;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> Register(CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }
    }
}