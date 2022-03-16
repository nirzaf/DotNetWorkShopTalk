using Hangfire;

namespace DHangfire;

public interface IJobService
{
    Task JobWithNameAsync();
}

public class JobService : IJobService
{
    [JobDisplayName("Custom Job Name")]
    public async Task JobWithNameAsync()
    {
        await Task.Delay(5000);
        Console.WriteLine("Named method recurring every minute!");
    }

}
