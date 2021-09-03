using System;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IProjectRepository Projects { get; }
        IRepository<MyTask> Tasks { get; }
        int Save();
    }
}
