using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;

namespace BBackgroundService.Dashboard
{
    public class DashboardCacheRefresherBackgroundService : BackgroundService
    {
        private readonly ILogger<DashboardCacheRefresherBackgroundService> _logger;
        private readonly ICacheService _cacheService;

        public DashboardCacheRefresherBackgroundService(ILogger<DashboardCacheRefresherBackgroundService> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Job starts
            _logger.LogInformation("Starting {jobName}", nameof(DashboardCacheRefresherBackgroundService));

            // Continue until the app shuts down
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _cacheService.RefreshDashboardCacheAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Job {jobName} threw an exception", nameof(DashboardCacheRefresherBackgroundService));
                }

                await Task.Delay(5000);
            }
            
            // Job ends
            _logger.LogInformation("Stopping {jobName}", nameof(DashboardCacheRefresherBackgroundService));
            _cacheService.RemoveDashboardCache();
        }
    }
}