using CWorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Microsoft.Extensions.Hosting.WindowsService
    .UseSystemd() // Microsoft.Extensions.Hosting.Systemd
    .ConfigureServices((_, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDemoServices();
    })
    .Build();
    
await host.RunAsync();
