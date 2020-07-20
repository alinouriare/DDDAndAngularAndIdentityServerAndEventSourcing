using Infrastructure.Interceptors;
using Infrastructure.Logging;
using System.Collections.Generic;

namespace IdentityServer.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public LoggingOptions Logging { get; set; }

        public Dictionary<string, string> SecurityHeaders { get; set; }

        public CertificatesOptions Certificates { get; set; }

        public InterceptorsOptions Interceptors { get; set; }
    }
}
