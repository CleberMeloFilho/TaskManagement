using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces
{
    public interface IMessageService
    {
        System.Threading.Tasks.Task Publish(string message);
    }
}