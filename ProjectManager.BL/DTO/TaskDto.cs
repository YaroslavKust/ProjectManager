using ProjectManager.DAL.Models;

namespace ProjectManager.BL.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ProgressInPercents { get; set; }
        public int ProjectId { get; set; }
    }

    public enum Priority
    {
        High = 1,
        Normal = 2,
        Low = 3
    }
}