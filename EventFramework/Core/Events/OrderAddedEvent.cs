using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BusinessComponents;
using EventFramework;

namespace Core.Events
{
    public class OrderAddedEvent : BaseEvent
    {
        private OrderComponent newOrder;
        public OrderAddedEvent(OrderComponent newOrder)
        {
            this.newOrder = newOrder;
        }
    }
}
