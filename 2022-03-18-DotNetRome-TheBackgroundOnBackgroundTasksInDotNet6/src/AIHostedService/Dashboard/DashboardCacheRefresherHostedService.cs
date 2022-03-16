using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;

#pragma warning disable 4014

namespace AIHostedService.Dashboard;

public class DashboardCacheRefresherHostedService : IHostedService
{
    private readonly ILogger<DashboardCacheRefresherHostedService> _logger;
    private readonly ICacheService _cacheService;

    public DashboardCacheRefresherHostedService(ILogger<DashboardCacheRefresherHostedService> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting {jobName}", nameof(DashboardCacheRefresherHostedService));
        
        RefreshCacheAsync(cancellationToken);
        
        return Task.CompletedTask;
    }
        
    private async Task RefreshCacheAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await _cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Job {jobName} threw an exception", nameof(DashboardCacheRefresherHostedService));
            }

            await Task.Delay(5000, stoppingToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping {jobName}", nameof(DashboardCacheRefresherHostedService));

        // Perform any cleanup here
        _cacheService.RemoveDashboardCache();

        return Task.CompletedTask;
    }
}