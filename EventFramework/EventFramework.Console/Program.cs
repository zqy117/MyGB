using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Applications;
using Core.BusinessComponents;
using Core.Interfaces;
using Core.Repository;

namespace EventFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            StartupConfig.ConfigEventProcessors();

            //register interface:concrete class
            SysRuntime.Container.Register<IOrderAppFacade, OrderApplication>();
            SysRuntime.Container.Register<IOrderBusiness, OrderComponent>();
            SysRuntime.Container.Register<IOrderRepository, FakeOrderRepository>();

            IOrderAppFacade orderApp = SysRuntime.Container.Resolve<IOrderAppFacade>();
            orderApp.AddOrder("test");
        }
    }
}
