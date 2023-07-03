﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByDate(DateTime date);
        IEnumerable<Order> GetOrdersByPrice(double price);
    }
}
