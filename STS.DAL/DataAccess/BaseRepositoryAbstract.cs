using STS.DAL.EntityContext.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess
{
    public abstract class BaseRepositoryAbstract<T> : IBaseRepository<T> where T : class
    {
        private SubjectContext _subjectContext;

        public async Task<int> CreateAsync(T entity)
        {
            await _subjectContext.Set<T>().AddAsync(entity);

            var result = await _subjectContext.SaveChangesAsync();

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