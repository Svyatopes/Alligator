﻿using Alligator.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IOrderRepository
    {
        int AddOrder(DateTime date, int clientId, string address);
        void DeleteOrder(int id);
        void EditOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        List<Order> GetOrdersByClientId(int id);
    }
}