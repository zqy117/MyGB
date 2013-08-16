﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        int Insert(OrderEntity order);

        bool Update(OrderEntity order);

        OrderEntity Get(int orderId);
    }
}
