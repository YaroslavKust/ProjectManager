using System;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Project> Projects { get; }
        IRepository<MyTask> Tasks { get; }
        int Save();
    }
}
