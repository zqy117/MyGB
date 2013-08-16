using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventFramework
{
    public sealed class Container
    {
        private static Dictionary<Type, Type> typeMappers = new Dictionary<Type, Type>();

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)Resolve(typeof(TInterface));
        }
        public object Resolve(Type TInterface)
        {
            if (!typeMappers.ContainsKey(TInterface))
                throw new Exception("Key empty, register please");

            //Create new instance
            Type type = typeMappers[TInterface];
            object obj = Activator.CreateInstance(type);

            //DIAttribute
            InjectDIAttributresIfExists(type, obj);

            if (ExistsTag(TInterface, typeof(RaiseEventAttribute)))
            {
                //Dynamic Agent, check [RaiseEventAttribute]
                MarshalByRefObject mbro = obj as MarshalByRefObject;
                DynamicProxy proxy = new DynamicProxy(TInterface, mbro);
                return proxy.GetTransparentProxy();
            }
            return obj;
        }

        
        
        public void Register<TInterface, TProvider>()
            where TProvider : class, new()
        {
            if (typeMappers.ContainsKey(typeof(TInterface)))
                throw new Exception("Key existed");

            typeMappers.Add(typeof(TInterface), typeof(TProvider));
        }



        private void InjectDIAttributresIfExists(Type type, object obj)
        {
            //Inject [DIAttriute]
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo fi in fieldInfos)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DIAttribute), false);
                if (attrs == null || attrs.Count() == 0)
                    continue;

                //Resolve One, and inject
                object o = this.Resolve(fi.FieldType);
                if (o == null)
                    throw new Exception(string.Format("Cannot resolve {0}", fi.FieldType.ToString()));
                fi.SetValue(obj, o);
            }
        }
        private bool ExistsTag(Type type, Type findAttrType)
        {
            MethodInfo[] methodInfos=type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Public);
            if (methodInfos == null || methodInfos.Count() == 0)
                return false;

            foreach(MethodInfo mi in methodInfos)
            {
                object[] attrs=mi.GetCustomAttributes(findAttrType, false);
                if (attrs != null && attrs.Count() > 0)
                    return true;
            }

            return false;
        }
    }
}
