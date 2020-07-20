using CrossCuttingsConcerns.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Caching.Redis
{
    public class Cache : ICache
    {
        public void Add(string key, object item, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
