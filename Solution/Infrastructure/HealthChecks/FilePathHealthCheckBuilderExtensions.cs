using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HealthChecks
{
    public static class FilePathHealthCheckBuilderExtensions
    {
        public static IHealthChecksBuilder AddFilePathWrite(this IHealthChecksBuilder builder, string path, string name, HealthStatus failureStatus, IEnumerable<string> tags = default)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            return builder.Add(new HealthCheckRegistration(
                name,
                new FilePathWriteHealthCheck(path),
                failureStatus,
                tags));
        }

    }
}
