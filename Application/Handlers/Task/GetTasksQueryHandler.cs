using MediatR;
using TaskManagement.Application.Queries.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace TaskManagement.Application.Handlers.Tasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, PagedList<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<PagedList<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();

            var query = tasks.AsQueryable();

            // Ordenação dinâmica usando reflexão
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var propertyInfo = typeof(Task).GetProperty(request.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    query = request.SortAscending
                        ? query.OrderBy(t => propertyInfo.GetValue(t, null))
                        : query.OrderByDescending(t => propertyInfo.GetValue(t, null));
                }
            }

            // Paginação
            var pagedTasks = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    AssignedUserId = t.AssignedUserId,
                    ProjectId = t.ProjectId
                })
                .ToList();

            var totalCount = tasks.Count();

            return new PagedList<TaskDto>(pagedTasks, totalCount, request.PageNumber, request.PageSize);
        }
    }
}