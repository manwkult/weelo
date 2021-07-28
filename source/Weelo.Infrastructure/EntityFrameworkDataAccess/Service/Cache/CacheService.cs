namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;

    public class CacheService<T> : ICacheService<T> where T : class
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<List<T>> GetAsync(string key)
        {
            var value = await _cache.GetStringAsync(key);

            if (value != null)
            {
                return JsonConvert.DeserializeObject<List<T>>(value);
            }

            return default;
        }

        public async Task SetAsync(string key, List<T> value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);
        }

        public async Task DeleteAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}