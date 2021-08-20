
namespace ProjectManager.DAL.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProgressInPercents { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

    public enum Priority
    {
        High = 1,
        Normal = 2,
        Low = 3
    }
}
