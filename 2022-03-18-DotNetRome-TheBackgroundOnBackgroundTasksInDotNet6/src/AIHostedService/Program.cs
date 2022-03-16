using AIHostedService.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddHostedService<DashboardCacheRefresherHostedService>();
builder.Services.AddDemoServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();