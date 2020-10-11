using System;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace DHangfire.Controllers
{
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
                () => TriggeredFromController("Hello from the Controller!"));
        }

        [JobDisplayName("Triggered from Controller with - {0}")]
        public void TriggeredFromController(string value)
        {
            Console.WriteLine(value);
        }
    }
}