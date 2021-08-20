using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectManager.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}