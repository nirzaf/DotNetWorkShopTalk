using CWorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Microsoft.Extensions.Hosting.WindowsService
    .UseSystemd() // Microsoft.Extensions.Hosting.Systemd
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDemoServices();
    })
    .Build();
    
await host.RunAsync();