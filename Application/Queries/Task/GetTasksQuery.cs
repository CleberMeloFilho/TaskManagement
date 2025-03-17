using MediatR;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Queries.Tasks
{
    public class GetTasksQuery : IRequest<PagedList<TaskDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "Title";
        public bool SortAscending { get; set; } = true;
    }
}