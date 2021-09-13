using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dataSet;
        private DbContext _context;

        protected DbSet<T> DataSet => _dataSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _dataSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression = null)
        {
            return await Task.Run(() => 
                expression == null ?
                _dataSet.AsNoTracking().AsEnumerable() : _dataSet.Where(expression).AsNoTracking().AsEnumerable());
        }

        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dataSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) 
        {
            _dataSet.Attach(entity);
            _dataSet.Remove(entity);
        }
    }
}