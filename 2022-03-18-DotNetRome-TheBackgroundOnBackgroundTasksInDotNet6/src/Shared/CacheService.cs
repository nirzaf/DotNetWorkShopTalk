using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Shared;

public interface ICacheService
{
    Task RefreshDashboardCacheAsync();
    void RemoveDashboardCache();
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
        
    public async Task RefreshDashboardCacheAsync()
    {
        var rng = new Random();
        var dashboardResult = new DashboardResult
        {
            AverageSale = rng.Next(1, 2_000),
            LastUpdated = DateTime.UtcNow,
            NumberOfSales = rng.Next(1, 10_000)
        };
        var encodedDashboard = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dashboardResult));

        await _cache.SetAsync(CacheKeys.Dashboard, encodedDashboard, new DistributedCacheEntryOptions());

        _logger.LogInformation("{cacheKey} cache refreshed", CacheKeys.Dashboard);
    }

    public void RemoveDashboardCache()
    {
        _cache.Remove(CacheKeys.Dashboard);
    }
}
