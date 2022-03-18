using System;
using System.Threading.Tasks;
using DHangfire;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

var hangfireConnectionString = builder.Configuration.GetConnectionString("Hangfire");
await DatabaseHelpers.CreateHangfireDatabaseIfItDoesntExistAsync(hangfireConnectionString);
builder.Services.AddControllers();
builder.Services.AddDemoServices();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddHangfire(hangfireConfig =>
{
    hangfireConfig
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(hangfireConnectionString,
            new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            });
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHangfireDashboard();

RecurringJob.AddOrUpdate(
    () => Console.WriteLine("Inline method recurring every minute!"),
    Cron.Minutely);

RecurringJob.AddOrUpdate(
    () => app.Services.GetRequiredService<IJobService>().JobWithNameAsync(),
    Cron.Minutely
);

app.Run();
