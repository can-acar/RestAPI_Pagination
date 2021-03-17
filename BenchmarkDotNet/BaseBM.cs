using BenchmarkDotNet.Attributes;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class BaseBM : ICache
    {
        MemoryCache cache = MemoryCache.Default;

        public T GetCache<T>(string name) where T : class
        {

            return cache.Get(name) as T;
        }


        public void SetCache<T>(string name, T value) where T : class
        {
            cache.Add(name, value, DateTime.Now.AddHours(5));
        }

    }


}
