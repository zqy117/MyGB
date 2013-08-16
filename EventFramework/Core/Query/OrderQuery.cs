using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using EventFramework;

namespace Core.Query
{
    public class OrderQuery
    {
        public List<OrderDTO> GetOrdersByMemberUser(int userId)
        {
            List<OrderDTO> lst = SysRuntime.CacheService.Get<List<OrderDTO>>("OrdersByMemberUser:" + userId);
            if (lst == null)
            { 
                //begin load from repository
                lst = new List<OrderDTO>();
                //end load from repository

                SysRuntime.CacheService.Put<List<OrderDTO>>("OrdersByMemberUser:" + userId, lst);
            }
            return lst;
        }

        public List<OrderDTO> GetPendingOrdersByAdminUser(int userId)
        {
            List<OrderDTO> lst = SysRuntime.CacheService.Get<List<OrderDTO>>("PendingOrders");
            if (lst == null)
            {
                //begin load from repository
                lst = new List<OrderDTO>();
                //end load from repository

                SysRuntime.CacheService.Put<List<OrderDTO>>("PendingOrders:" + userId, lst);
            }
            return lst;
        }
    }
}
