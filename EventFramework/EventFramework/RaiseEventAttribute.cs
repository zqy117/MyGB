using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    [AttributeUsage( AttributeTargets.Method, AllowMultiple=true)]
    public class RaiseEventAttribute:Attribute
    {
        public Type EventType { get; set; }
        public RaiseEventAttribute(Type eventType)
        {
            this.EventType = eventType;
        }
    }
}
