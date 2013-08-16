using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Events;
using EventFramework;

namespace Core.Interfaces
{
    public interface IOrderBusiness
    {
        [RaiseEvent(typeof(OrderSavedEvent))]
        [RaiseEvent(typeof(OrderSavedEvent))]
        int Add(OrderEntity order);

        [RaiseEvent(typeof(OrderSavedEvent))]
        bool Save(OrderEntity order);

        [RaiseEvent(typeof(OrderDeletedEvent))]
        bool Delete(int orderId);
    }
}
