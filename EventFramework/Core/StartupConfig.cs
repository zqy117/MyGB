using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EventProcessors;
using Core.Events;
using EventFramework;

namespace Core
{
    public static class StartupConfig
    {
        public static void ConfigEventProcessors()
        {
            //Subscribe OrderAddedEvent
            SysRuntime.EventBus.Subscribe<OrderAddedEvent, AdminPendingOrderListCacheBuilder>();
            SysRuntime.EventBus.Subscribe<OrderAddedEvent, PerUserOrderListCacheBuilder>();

            //Subscribe OrderDeletedEvent
            SysRuntime.EventBus.Subscribe<OrderDeletedEvent, SampleOrderDeletedEventProcessor>();

            //Subscribe OrderSavedEvent
            SysRuntime.EventBus.Subscribe<OrderSavedEvent, SampleOrderSavedEventProcessor>();
        }
    }
}
