using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.BaseRepository
{
    public interface IBaseRepository<T>
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);
    }
}