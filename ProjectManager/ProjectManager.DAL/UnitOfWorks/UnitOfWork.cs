using System.Data.Entity;
using System.Threading.Tasks;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.DAL.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private IUserRepository _users;
        private IProjectRepository _projects;
        private IRepository<MyTask> _tasks;

        private readonly DbContext _db;

        public UnitOfWork()
        {
            _db = new ManagerContext();
        }

        public IUserRepository Users => _users ?? (_users = new UserRepository(_db));

        public IProjectRepository Projects => _projects ?? (_projects = new ProjectRepository(_db));

        public IRepository<MyTask> Tasks => _tasks ?? (_tasks = new Repository<MyTask>(_db));

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
