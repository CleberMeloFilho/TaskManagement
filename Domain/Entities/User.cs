using System.Collections.Generic;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } // "Admin" ou "User"
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}