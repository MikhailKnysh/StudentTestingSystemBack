using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess
{
    public abstract class BaseRepositoryAbstract<T> : IBaseRepository<T>
    {
        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}