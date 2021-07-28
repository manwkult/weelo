namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache
{
    using Microsoft.Extensions.Caching.Distributed;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class OwnerCacheService : CacheService<OwnerEntity>, IOwnerCacheService
    {
        public OwnerCacheService(IDistributedCache cache) : base(cache)
        { }
    }
}