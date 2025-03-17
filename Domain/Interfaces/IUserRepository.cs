using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;


namespace TaskManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}