using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingsConcerns.ExtensionMethods
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
