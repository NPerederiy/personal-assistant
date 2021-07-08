using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
