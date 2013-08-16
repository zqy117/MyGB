using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Repository
{
    public class FakeOrderRepository:IOrderRepository
    {
        private List<Entities.OrderEntity> list = new List<Entities.OrderEntity>();
        public int Insert(Entities.OrderEntity order)
        {
            Random rdn = new Random();
            order.OrderID = rdn.Next(1000);
            list.Add(order);
            return order.OrderID;
        }

        public bool Update(Entities.OrderEntity order)
        {
            return true;
        }

        public Entities.OrderEntity Get(int orderId)
        {
            return list.First(t=>t.OrderID==orderId);
        }
    }
}
