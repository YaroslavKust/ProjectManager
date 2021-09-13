using ProjectManager.DAL.Migrations;
using System.Data.Entity;

namespace ProjectManager.DAL.Models
{
    public class ManagerContext: DbContext
    {
        public ManagerContext() : base("DBConnection") 
        {
            Database.SetInitializer<ManagerContext>
                (new MigrateDatabaseToLatestVersion<ManagerContext, Configuration>());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
    }
}