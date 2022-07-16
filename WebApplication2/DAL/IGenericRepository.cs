using System.Linq.Expressions;

namespace WebApplication2.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expresssion);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
