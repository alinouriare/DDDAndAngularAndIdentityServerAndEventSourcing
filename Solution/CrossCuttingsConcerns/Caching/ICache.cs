using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingsConcerns.Caching
{
   public interface ICache
    {

        void Add(string key, object items, TimeSpan timeSpan);

        void Remove(string key);

        object Get(string key);
    }
}
