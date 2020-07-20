using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ConfigurationOptions
{
    public class CORS
    {
        public bool AllowAnyOrigin { get; set; }

        public string[] AllowedOrigins { get; set; }
    }
}
