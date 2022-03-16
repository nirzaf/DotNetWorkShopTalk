using Hangfire;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable MemberCanBePrivate.Global

namespace DHangfire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangfireController
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public HangfireController(IBackgroundJobClient backgroundJobClient)
    {
        _backgroundJobClient = backgroundJobClient;
    }
        
    [HttpGet]
    public void Trigger()
    {
        _backgroundJobClient.Enqueue(
            () => TriggeredFromControllerAsync("Hello from the Controller!"));
    }

    [JobDisplayName("Triggered from Controller with - {0}")]
    public static async Task TriggeredFromControllerAsync(string value)
    {
        await Task.Delay(5000);
        Console.WriteLine(value);
    }
}
