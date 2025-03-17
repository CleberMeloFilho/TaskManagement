using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        System.Threading.Tasks.Task AddAsync(Project project);
        System.Threading.Tasks.Task UpdateAsync(Project project);
        System.Threading.Tasks.Task DeleteAsync(int id);
    }
}