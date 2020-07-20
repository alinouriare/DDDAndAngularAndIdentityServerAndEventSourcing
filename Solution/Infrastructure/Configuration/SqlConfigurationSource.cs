using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class SqlConfigurationSource : IConfigurationSource
    {

        private readonly SqlServerSourceOptions _options;

        public SqlConfigurationSource(SqlServerSourceOptions options)
        {
            _options = options;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlConfigurationProvider(_options);
        }
    }
}
