using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Events;
using Core.Interfaces;
using EventFramework;

namespace Core.BusinessComponents
{
    public class OrderComponent : MarshalByRefObject, IOrderBusiness
    {
        [DI]
        private IOrderRepository repository;

        public int Add(OrderEntity order)
        {
            //validate 
            Console.WriteLine("In Add");
            int newOrderId= repository.Insert(order);
            if (newOrderId>0)
                SysRuntime.EventBus.RaiseEvent<OrderAddedEvent>(order);
            return newOrderId;
        }

        
        public bool Save(OrderEntity order)
        {
            //validate 
            return repository.Update(order);
        }

        
        public bool Delete(int orderId)
        {
            OrderEntity order = this.repository.Get(orderId);
            order.IsDeleted = true;
            return repository.Update(order);
        }
    }
}
