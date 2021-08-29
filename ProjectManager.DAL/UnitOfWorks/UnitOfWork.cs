using System.Data.Entity;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private IRepository<User> _users;
        private IRepository<Project> _projects;
        private IRepository<MyTask> _tasks;

        private readonly DbContext _db;

        public UnitOfWork(string connectionString)
        {
            _db = new ManagerContext(connectionString);
        }

        public IRepository<User> Users => _users ?? (_users = new Repository<User>(_db));

        public IRepository<Project> Projects => _projects ?? (_projects = new Repository<Project>(_db));

        public IRepository<MyTask> Tasks => _tasks ?? (_tasks = new Repository<MyTask>(_db));

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
