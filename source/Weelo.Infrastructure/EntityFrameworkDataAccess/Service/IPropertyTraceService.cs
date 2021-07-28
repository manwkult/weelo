namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    
    public interface IPropertyTraceService
    {
        Task<PropertyTraceEntity> GetAsync(int id);
        Task<List<PropertyTraceEntity>> GetAllAsync();
        Task<IEnumerable<PropertyTraceEntity>> FindAsync(Expression<Func<PropertyTraceEntity, bool>> predicate);
        Task<PropertyTraceEntity> SingleOrDefaultAsync(Expression<Func<PropertyTraceEntity, bool>> predicate);
        Task<PropertyTraceEntity> AddOrUpdateAsync(PropertyTraceEntity entity);
        Task AddRangeAsync(IEnumerable<PropertyTraceEntity> entities);        
        Task<bool> RemoveAsync(PropertyTraceEntity entity);
        Task<bool> RemoveRangeAsync(IEnumerable<PropertyTraceEntity> entities);
    }
}