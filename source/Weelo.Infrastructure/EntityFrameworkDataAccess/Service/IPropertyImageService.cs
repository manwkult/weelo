namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public interface IPropertyImageService
    {
        Task<PropertyImageEntity> GetAsync(int id);
        Task<List<PropertyImageEntity>> GetAllAsync();
        Task<IEnumerable<PropertyImageEntity>> FindAsync(Expression<Func<PropertyImageEntity, bool>> predicate);
        Task<PropertyImageEntity> SingleOrDefaultAsync(Expression<Func<PropertyImageEntity, bool>> predicate);
        Task<PropertyImageEntity> AddOrUpdateAsync(PropertyImageEntity entity);
        Task AddRangeAsync(IEnumerable<PropertyImageEntity> entities);        
        Task<bool> RemoveAsync(PropertyImageEntity entity);
        Task<bool> RemoveRangeAsync(IEnumerable<PropertyImageEntity> entities);
        Task RemoveByPropertyIdAsync(long propertyId);
    }
}