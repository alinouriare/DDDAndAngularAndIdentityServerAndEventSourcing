using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Decorators.DatabaseRetry
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DatabaseRetryAttribute : Attribute
    {
        public int RetryTimes { get; }

        public DatabaseRetryAttribute(int retryTimes = 3)
        {
            RetryTimes = retryTimes;
        }
    }
}
