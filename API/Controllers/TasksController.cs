using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.Tasks;
using TaskManagement.Application.Queries.Tasks;
using TaskManagement.Application.DTOs;
using MediatR;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os endpoints do controlador
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "UserOnly")] // Apenas usuários com a role "User" podem acessar
        public async Task<ActionResult<int>> CreateTask(CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return Ok(taskId);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<TaskDto>>> GetTasks([FromQuery] GetTasksQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            var query = new GetTaskByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")] // Apenas usuários com a role "Admin" podem acessar
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")] // Apenas usuários com a role "Admin" podem acessar
        public async Task<IActionResult> DeleteTask(int id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}