using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Shared
{
    public interface ICacheService
    {
        Task RefreshCookieCacheAsync();
        void RemoveCookieCache();
    }

    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        
        public async Task RefreshCookieCacheAsync()
        {
            var rng = new Random();
            var lastUpdated = DateTime.UtcNow;
            var cookies = new List<Cookie>
            {
                new Cookie {Cost = rng.Next(1, 20), Flavor = "Chocolate Chip", LastUpdated = lastUpdated},
                new Cookie {Cost = rng.Next(1, 20), Flavor = "Sugar", LastUpdated = lastUpdated},
                new Cookie {Cost = rng.Next(1, 20), Flavor = "Peanut Butter", LastUpdated = lastUpdated},
            };
            var encodedCookies = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(cookies));

            await _cache.SetAsync(CacheKeys.Cookies, encodedCookies, new DistributedCacheEntryOptions());

            _logger.LogInformation("Cache key {cacheKey} refreshed", CacheKeys.Cookies);
        }

        public void RemoveCookieCache()
        {
            _cache.Remove(CacheKeys.Cookies);
        }
    }
}