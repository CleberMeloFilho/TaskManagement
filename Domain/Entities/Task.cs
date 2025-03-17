namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}