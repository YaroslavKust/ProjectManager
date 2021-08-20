using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Repositories;

namespace ProjectManager.UnitOfWorks
{
    interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Project> Projects { get; }
        IRepository<MyTask> Tasks { get; }
    }
}
