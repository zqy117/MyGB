using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BusinessComponents;
using EventFramework;

namespace Core.Events
{
    public class OrderDeletedEvent : BaseEvent
    {
        private OrderComponent newOrder;
        public OrderDeletedEvent(OrderComponent newOrder)
        {
            this.newOrder = newOrder;
        }
    }
}
