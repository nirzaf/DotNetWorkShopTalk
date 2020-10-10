using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared;

namespace AIHostedService.Cookie
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : Controller
    {
        private readonly IDistributedCache _cache;

        public CookieController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public async Task<IEnumerable<Shared.Cookie>> Get()
        {
            var encodedCookies = await _cache.GetAsync(CacheKeys.Cookies);
            var cookies = JsonSerializer.Deserialize<List<Shared.Cookie>>(Encoding.UTF8.GetString(encodedCookies));
            return cookies;
        }
    }
}