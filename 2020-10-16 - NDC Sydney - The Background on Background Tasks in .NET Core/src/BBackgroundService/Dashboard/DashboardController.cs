using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared;

namespace BBackgroundService.Dashboard
{
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
        public async Task<IEnumerable<Shared.DashboardResult>> Get()
        {
            var encodedDashboard = await _cache.GetAsync(CacheKeys.Dashboard);
            var dashboard = JsonSerializer.Deserialize<List<Shared.DashboardResult>>(Encoding.UTF8.GetString(encodedDashboard));
            return dashboard;
        }
    }
}