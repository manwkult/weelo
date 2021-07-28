using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);        
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}