using Microsoft.EntityFrameworkCore;
using STS.DAL.EntityContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace STS.DAL.DataAccess.BaseRepository
{
    public abstract class BaseRepositoryAbstract<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationContext _context;

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

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var set = _context.Set<T>().Update(entity);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            var entities = await _context.Set<T>().Where(expression).ToListAsync();

            return entities;
        }
    }
}