using ProjectManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task<IEnumerable<Project>> GetWithTasksAsync(Expression<Func<Project, bool>> exp);
    }
}
