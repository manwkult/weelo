namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache
{
    using Microsoft.Extensions.Caching.Distributed;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class PropertyImageCacheService : CacheService<PropertyImageEntity>, IPropertyImageCacheService
    {
        public PropertyImageCacheService(IDistributedCache cache) : base(cache)
        { }
    }
}