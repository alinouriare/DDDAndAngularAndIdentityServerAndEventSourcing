using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public class EventLogOptions
    {
        public bool IsEnabled { get; set; }

        public string LogName { get; set; }

        public string SourceName { get; set; }
    }
}
