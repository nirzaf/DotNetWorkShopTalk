using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;

#pragma warning disable 4014

namespace AIHostedService.Cookie
{
    public class CookieHostedService : IHostedService
    {
        private readonly ILogger<CookieHostedService> _logger;
        private readonly ICacheService _cacheService;

        public CookieHostedService(ILogger<CookieHostedService> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting {jobName}", nameof(CookieHostedService));
        
            RefreshCacheAsync(cancellationToken);
        
            return Task.CompletedTask;
        }
        
        private async Task RefreshCacheAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _cacheService.RefreshCookieCacheAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Job {jobName} threw an exception", nameof(CookieHostedService));
                }

                await Task.Delay(5000, stoppingToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping {jobName}", nameof(CookieHostedService));

            // Perform any cleanup here
            _cacheService.RemoveCookieCache();

            return Task.CompletedTask;
        }
    }
}