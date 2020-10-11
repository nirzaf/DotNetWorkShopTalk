using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;

namespace BBackgroundService.Cookie
{
    public class CookieCacheRefresherBackgroundService : BackgroundService
    {
        private readonly ILogger<CookieCacheRefresherBackgroundService> _logger;
        private readonly ICacheService _cacheService;

        public CookieCacheRefresherBackgroundService(ILogger<CookieCacheRefresherBackgroundService> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Job starts
            _logger.LogInformation("Starting {jobName}", nameof(CookieCacheRefresherBackgroundService));

            // Continue until the app shuts down
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _cacheService.RefreshCookieCacheAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Job {jobName} threw an exception", nameof(CookieCacheRefresherBackgroundService));
                }

                await Task.Delay(5000);
            }
            
            // Job ends
            _logger.LogInformation("Stopping {jobName}", nameof(CookieCacheRefresherBackgroundService));
            _cacheService.RemoveCookieCache();
        }
    }
}