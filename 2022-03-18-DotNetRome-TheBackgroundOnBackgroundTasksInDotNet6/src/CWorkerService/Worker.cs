using Shared;

namespace CWorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ICacheService _cacheService;

    public Worker(ILogger<Worker> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }
        
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Job starts
        _logger.LogInformation("Starting {jobName}", nameof(Worker));

        // Continue until the app shuts down
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await _cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Job {jobName} threw an exception", nameof(Worker));
            }

            await Task.Delay(5000, stoppingToken);
        }
            
        // Job ends
        _logger.LogInformation("Stopping {jobName}", nameof(Worker));
        _cacheService.RemoveDashboardCache();
    }
}
