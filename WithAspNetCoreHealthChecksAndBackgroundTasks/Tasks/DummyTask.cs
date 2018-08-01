using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WithAspNetCoreHealthChecksAndBackgroundTasks.Tasks
{
    public class DummyTask : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Do something...

                await Task.Delay(5000, stoppingToken);
            }

            await Task.CompletedTask;
        }
    }
}
