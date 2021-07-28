namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public interface IOwnerService
    {
        Task<OwnerEntity> GetAsync(int id);
        Task<List<OwnerEntity>> GetAllAsync();
        Task<IEnumerable<OwnerEntity>> FindAsync(Expression<Func<OwnerEntity, bool>> predicate);
        Task<OwnerEntity> SingleOrDefaultAsync(Expression<Func<OwnerEntity, bool>> predicate);
        Task<OwnerEntity> AddOrUpdateAsync(OwnerEntity entity);
        Task AddRangeAsync(IEnumerable<OwnerEntity> entities);        
        Task<bool> RemoveAsync(OwnerEntity entity);
        Task<bool> RemoveRangeAsync(IEnumerable<OwnerEntity> entities);
    }
}