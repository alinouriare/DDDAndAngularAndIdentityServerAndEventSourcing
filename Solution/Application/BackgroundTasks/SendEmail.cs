using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BackgroundTasks
{
    public class SendEmail
    {
        private readonly ILogger _logger;

        public SendEmail(ILogger<SendEmail> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Inside Send() method.");
        }
    }
}
