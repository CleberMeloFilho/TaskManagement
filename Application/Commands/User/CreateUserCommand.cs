using MediatR;

namespace TaskManagement.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin" ou "User"
    }
}