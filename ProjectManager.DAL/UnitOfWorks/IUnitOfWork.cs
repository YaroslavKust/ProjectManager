using ProjectManager.DAL.Models;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Project> Projects { get; }
        IRepository<MyTask> Tasks { get; }
    }
}
