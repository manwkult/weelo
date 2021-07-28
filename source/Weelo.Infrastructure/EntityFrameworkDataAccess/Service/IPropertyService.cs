using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    public interface IPropertyService
    {
        Task<PropertyEntity> GetAsync(int id);
        Task<List<PropertyEntity>> GetAllAsync();
        Task<List<PropertyEntity>> GetAllWhitOwnerAsync();
        Task<IEnumerable<PropertyEntity>> FindAsync(Expression<Func<PropertyEntity, bool>> predicate);
        Task<PropertyEntity> SingleOrDefaultAsync(Expression<Func<PropertyEntity, bool>> predicate);
        Task<PropertyEntity> AddOrUpdateAsync(PropertyEntity entity);
        Task<bool> ChangePriceAsync(long id, decimal price);
        Task AddRangeAsync(IEnumerable<PropertyEntity> entities);        
        Task<bool> RemoveAsync(PropertyEntity entity);
        Task<bool> RemoveRangeAsync(IEnumerable<PropertyEntity> entities);
    }
}