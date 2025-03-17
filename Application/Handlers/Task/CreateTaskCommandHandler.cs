using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Application.Commands.Tasks;

namespace TaskManagement.Application.Handlers.Tasks
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.Task
            {
                Title = request.Title,
                Description = request.Description,
                AssignedUserId = request.AssignedUserId,
                ProjectId = request.ProjectId
            };

            await _taskRepository.AddAsync(task);
            return task.Id;
        }
    }
}