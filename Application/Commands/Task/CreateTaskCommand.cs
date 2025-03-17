using MediatR;

namespace TaskManagement.Application.Commands.Tasks
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public int ProjectId { get; set; }
    }
}