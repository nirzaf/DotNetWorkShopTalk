using Microsoft.Extensions.Logging;
using Shared;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDemoServices(this IServiceCollection services)
    {
        services.AddSingleton<ICacheService, CacheService>();
        services.AddLogging(loggerConfig =>
        {
            loggerConfig.AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss]");
        });
                
        services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
    }
}