using MediatR;

namespace TaskManagement.Application.Commands.Tasks
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public int ProjectId { get; set; }
    }
}