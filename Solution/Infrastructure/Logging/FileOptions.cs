using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public class FileOptions
    {
        public LogEventLevel MinimumLogEventLevel { get; set; }
    }
}
