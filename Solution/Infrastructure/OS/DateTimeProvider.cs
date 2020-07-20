using CrossCuttingsConcerns.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OS
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
