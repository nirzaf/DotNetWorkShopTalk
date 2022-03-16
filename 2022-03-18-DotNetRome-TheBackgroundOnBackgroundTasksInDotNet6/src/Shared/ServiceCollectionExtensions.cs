using Microsoft.Extensions.Logging;
using Shared;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDemoServices(this IServiceCollection services)
        {
            services.AddSingleton<ICacheService, CacheService>();
            services.AddLogging(loggerConfig =>
            {
                loggerConfig.AddConsole(consoleConfig => consoleConfig.TimestampFormat = "[HH:mm:ss]");
            });
                
            services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
        }
    }
}