using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared;

namespace AIHostedService.Dashboard;

[ApiController]
[Route("[controller]")]
public class DashboardController : Controller
{
    private readonly IDistributedCache _cache;

    public DashboardController(IDistributedCache cache)
    {
        _cache = cache;
    }

    [HttpGet]
    public async Task<DashboardResult> Get()
    {
        var encodedDashboard = await _cache.GetAsync(CacheKeys.Dashboard);
        var dashboard = JsonSerializer.Deserialize<DashboardResult>(Encoding.UTF8.GetString(encodedDashboard));
        return dashboard;
    }
}
