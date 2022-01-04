﻿using Alligator.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(DateTime date, int clientId, string address);
        void DeleteOrder(int id);
        void EditOrder(DateTime date, int id, string address);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        List<Order> GetOrdersByClientId(int id);
    }
}