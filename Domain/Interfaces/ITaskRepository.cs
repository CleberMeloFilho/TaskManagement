using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskManagement.Domain.Entities.Task> GetByIdAsync(int id);
        Task<IEnumerable<TaskManagement.Domain.Entities.Task>> GetAllAsync();
        Task AddAsync(TaskManagement.Domain.Entities.Task task);
        Task UpdateAsync(TaskManagement.Domain.Entities.Task task);
        Task DeleteAsync(int id);
    }
}