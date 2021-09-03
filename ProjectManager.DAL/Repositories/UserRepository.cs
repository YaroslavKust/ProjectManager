using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManager.DAL.Models;

namespace ProjectManager.DAL.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context){ }

        public async Task<User> GetWithProjectsAsync(Expression<Func<User,bool>> exp)
        {
            return await DataSet.Include(u => u.Projects.Select(p => p.Tasks)).AsNoTracking().FirstOrDefaultAsync(exp);
        }
    }
}