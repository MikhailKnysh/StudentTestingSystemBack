using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> GetById(Guid id);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable> Where(Expression<Func<T, bool>> expression);
    }
}