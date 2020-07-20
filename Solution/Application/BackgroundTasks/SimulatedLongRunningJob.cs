using Domain.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BackgroundTasks
{
    public class SimulatedLongRunningJob
    {
        private readonly IWebNotification _notification;

        public SimulatedLongRunningJob(IWebNotification notification)
        {
            _notification = notification;
        }

        public async Task Run(string notificationServerEnpoint)
        {
            var endpoint = $"{notificationServerEnpoint}/SimulatedLongRunningTaskHub";
            await _notification.SendAsync(endpoint, "SendTaskStatus", new { Step = "Step 1", Message = "Begining xxx" });

            Thread.Sleep(2000);

            await _notification.SendAsync(endpoint, "SendTaskStatus", new { Step = "Step 1", Message = "Finished xxx" });
        }
    }
}
