using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    public class DynamicProxy : RealProxy
    {
        private MarshalByRefObject target;

        public DynamicProxy(Type objType, MarshalByRefObject obj):base(objType)
        {
            target = obj;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMessage retMsg = null;
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            IMethodReturnMessage methodReturn = null;
            object[] copiedArgs = Array.CreateInstance(typeof(object), methodCall.Args.Length) as object[];
            methodCall.Args.CopyTo(copiedArgs, 0);
            List<RaiseEventAttribute> eventRaisors = null;
            if (msg is IConstructionCallMessage)
            {

                IConstructionCallMessage ccm = (IConstructionCallMessage)msg;
                RemotingServices.GetRealProxy(target).InitializeServerObject(ccm);
                ObjRef oRef = RemotingServices.Marshal(target);
                RemotingServices.Unmarshal(oRef);
                retMsg = EnterpriseServicesHelper.CreateConstructionReturnMessage(ccm, (MarshalByRefObject)this.GetTransparentProxy());

            }
            else
            {
                IMethodCallMessage mcm = (IMethodCallMessage)msg;
                object[] attrs = methodCall.MethodBase.GetCustomAttributes(typeof(RaiseEventAttribute), false);
                if (attrs != null && attrs.Count() > 0)
                {
                    eventRaisors = new List<RaiseEventAttribute>();
                    foreach(object att in attrs)
                        eventRaisors.Add((RaiseEventAttribute)attrs[0]);
                }

                try
                {
                    object returnValue = methodCall.MethodBase.Invoke(this.target, copiedArgs);
                    methodReturn = new ReturnMessage(returnValue, copiedArgs, copiedArgs.Length, methodCall.LogicalCallContext, methodCall);

                    if (eventRaisors != null)
                        eventRaisors.ForEach(t=>SysRuntime.EventBus.RaiseEvent(t.EventType, null));
                }
                catch (Exception ex)
                {
                    if (null != ex.InnerException)
                    {
                        methodReturn = new ReturnMessage(ex.InnerException, methodCall);
                    }
                    else
                    {
                        methodReturn = new ReturnMessage(ex, methodCall);
                    }
                }
                retMsg = methodReturn;

            }
            return retMsg;
        }
    }
}
