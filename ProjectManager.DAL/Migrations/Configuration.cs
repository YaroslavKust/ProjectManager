using System.Data.Entity.Migrations;
using ProjectManager.DAL.Models;

namespace ProjectManager.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProjectManager.Models.ManagerContext";
        }

        protected override void Seed(ManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
