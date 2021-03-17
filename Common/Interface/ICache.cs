using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface ICache
    {
        T GetCache<T>(string name) where T : class;
        void SetCache<T>(string name, T value) where T : class;
    }
}
