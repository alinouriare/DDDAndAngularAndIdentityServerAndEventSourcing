using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure.Configuration
{
   public class SqlConfigurationProvider: ConfigurationProvider
    {
        private readonly SqlServerSourceOptions _options;

        public SqlConfigurationProvider(SqlServerSourceOptions options)
        {
            _options = options;
        }

        public override void Load()
        {
            using (var conn = new SqlConnection(_options.ConnectionString))
            {
                conn.Open();
                Data = conn.Query<ConfigurationEntry>(_options.SqlQuery).ToDictionary(c => c.Key, c => c.Value);
            }
        }
    }


    public class ConfigurationEntry
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
