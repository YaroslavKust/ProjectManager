using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManager.DAL.Models;

namespace ProjectManager.DAL.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetWithProjectsAsync(Expression<Func<User, bool>> exp);
    }
}