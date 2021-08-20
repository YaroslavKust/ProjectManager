using System.Data.Entity;

namespace ProjectManager.Models
{
    public class ManagerContext: DbContext
    {
        public ManagerContext() : base("DBConnection") { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
    }
}