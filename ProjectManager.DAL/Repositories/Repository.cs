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

        public Repository(DbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _dataSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression = null) => 
            expression == null ? await _dataSet.ToListAsync() : await  _dataSet.Where(expression).ToListAsync();

        public void Add(T entity) =>  _dataSet.Add(entity);

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _dataSet.Remove(entity);
    }
}