using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManager.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dataSet;
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public T GetById(int id) => _dataSet.Find(id);

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression = null) => 
            expression == null ? _dataSet.ToList() : _dataSet.Where(expression).ToList();

        public void Add(T entity) => _dataSet.Add(entity);

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _dataSet.Remove(entity);
    }
}