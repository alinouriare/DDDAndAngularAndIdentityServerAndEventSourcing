using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BackgroundTasks
{
    public class SendSms
    {
        private readonly ILogger _logger;

        public SendSms(ILogger<SendSms> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Inside Send() method.");
        }
    }
}
