namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache;

    public class PropertyCacheService : CacheService<PropertyEntity>, IPropertyCacheService
    {
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;

        public PropertyCacheService(IDistributedCache cache, IMapper mapper) : base(cache)
        {
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<List<PropertyEntity>> GetAsync(string key)
        {
            var value = await _cache.GetStringAsync(key);

            if (value != null)
            {
                var data = JsonConvert.DeserializeObject<List<PropertyCache>>(value);
                return data.Select(x => _mapper.Map<PropertyEntity>(x)).ToList();
            }

            return default;
        }

        public async Task SetAsync(string key, List<PropertyEntity> value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            var data = value.Select(x => _mapper.Map<PropertyCache>(x)).ToList();

            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(data), options);
        }
    }
}