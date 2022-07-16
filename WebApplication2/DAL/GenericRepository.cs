using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication2.DAL.Db;

namespace WebApplication2.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private WebApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;
        public GenericRepository(WebApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public virtual async Task Insert(T entity) => await _dbSet.AddAsync(entity);
        public virtual async Task Delete(T entity) => await Task.Run(() => _dbSet.Remove(entity));
        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expresssion) => await (Task<IEnumerable<T>>)_dbSet.Where<T>(expresssion);
        public virtual async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync<T>();
        public virtual async Task<T> GetById(int id) => await _dbSet.FindAsync(id);
        public virtual async Task Update(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            });
        }
    }
}
