namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache
{
    using Microsoft.Extensions.Caching.Distributed;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class PropertyTraceCacheService : CacheService<PropertyTraceEntity>, IPropertyTraceCacheService
    {
        public PropertyTraceCacheService(IDistributedCache cache) : base(cache)
        { }
    }
}