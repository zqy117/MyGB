using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    public static class SysRuntime
    {
        public static readonly EventBus EventBus=new EventBus();
        public static readonly ICache CacheService;
        public static readonly Container Container = new Container();
    }
}
