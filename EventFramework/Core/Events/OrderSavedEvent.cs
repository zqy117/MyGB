using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BusinessComponents;
using EventFramework;

namespace Core.Events
{
    public class OrderSavedEvent : BaseEvent
    {
        private OrderComponent newOrder;
        public OrderSavedEvent(OrderComponent newOrder)
        {
            this.newOrder = newOrder;
        }
    }
}
