using ProjectManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    class ProjectRepository: Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext context): base(context) { }
        public async Task<IEnumerable<Project>> GetWithTasksAsync(Expression<Func<Project, bool>> exp)
        {
            return await DataSet.Include(p => p.Tasks).AsNoTracking().Where(exp).ToListAsync();
        }
    }
}
