using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
   public static class SqlConfigurationExtensions
    {

        public static IConfigurationBuilder AddSqlConfigurationVariables(this IConfigurationBuilder builder, SqlServerSourceOptions options)
        {
            return builder.Add(new SqlConfigurationSource(options));
        }
    }
}
