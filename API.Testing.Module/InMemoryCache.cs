using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using ApiTestingFramework.Interfaces;

namespace ApiTestingFramework
{
    internal class InMemoryCache : ICacheService

    {
        public T Get<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default.Get(cacheKey) as T;
        }

        public void Set(string cacheKey, object item)
        {
            throw new NotImplementedException();
        }

        public void Set(string cacheKey, object item, int minutes = 30)
        {
            if (item != null)
            {
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minutes));
            }
        }

    }
}
