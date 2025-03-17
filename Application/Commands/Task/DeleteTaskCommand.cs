using MediatR;

namespace TaskManagement.Application.Commands.Tasks
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}