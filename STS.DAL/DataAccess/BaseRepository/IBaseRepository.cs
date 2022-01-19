using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.BaseRepository
{
    public interface IBaseRepository<T>
    {
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);
    }
}