using MediatR;

namespace TaskManagement.Application.Queries.Users
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}