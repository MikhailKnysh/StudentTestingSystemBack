using STS.DAL.EntityContext.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.BaseRepository
{
    public abstract class BaseRepositoryAbstract<T> : IBaseRepository<T> where T : class
    {
        private ApplicationContext _context;

        public BaseRepositoryAbstract(
            ApplicationContext context
        )
        {
            _context = context;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}