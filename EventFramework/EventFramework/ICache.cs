using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    public interface ICache
    {
        object Get(string key);
        T Get<T>(string key);
        void Put(string key, object o);
        void Put<T>(string key, T o);
    }
}
