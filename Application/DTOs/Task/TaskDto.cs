namespace TaskManagement.Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public int ProjectId { get; set; }
    }
}