using System.Data.Entity;

namespace ProjectManager.DAL.Models
{
    public class ManagerContext: DbContext
    {
        public ManagerContext(string connectionString) : base(connectionString) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
    }
}