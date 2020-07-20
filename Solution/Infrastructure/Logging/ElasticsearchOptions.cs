using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public class ElasticsearchOptions
    {
        public bool IsEnabled { get; set; }

        public string Host { get; set; }

        public string IndexFormat { get; set; }

        public LogEventLevel MinimumLogEventLevel { get; set; }
    }
}
