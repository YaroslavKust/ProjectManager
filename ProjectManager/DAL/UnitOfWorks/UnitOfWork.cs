using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Repositories;

namespace ProjectManager.UnitOfWorks
{
    class UnitOfWork: IUnitOfWork
    {
        private IRepository<User> _users;
        private IRepository<Project> _projects;
        private IRepository<MyTask> _tasks;

        private readonly DbContext _db;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        public IRepository<User> Users => _users ?? (_users = new Repository<User>(_db));

        public IRepository<Project> Projects => _projects ?? (_projects = new Repository<Project>(_db));

        public IRepository<MyTask> Tasks => _tasks ?? (_tasks = new Repository<MyTask>(_db));
    }
}
