using FinancialControl.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories.Implementations
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
