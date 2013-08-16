using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Query;
using EventFramework;

namespace Core.Applications
{
    public class OrderApplication : MarshalByRefObject, IOrderAppFacade
    {
        [DI]
        private IOrderBusiness orderBusiness;

        [DI]
        private IOrderRepository orderRepository;
        
        public int AddOrder(string title)
        {
            //begin mapping values to order business component
            OrderEntity order = new OrderEntity();
            order.Title = title;
            //end mapping values to order business component

            return orderBusiness.Add(order);
        }


        private OrderQuery orderQuery;
        public OrderQuery OrderQuery
        {
            get
            {
                if (orderQuery == null)
                    orderQuery = new OrderQuery();
                return orderQuery;
            }
        }
    }
}
