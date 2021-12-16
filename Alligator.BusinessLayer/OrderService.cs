using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class OrderService
    {
        private readonly RepositoryOrder _repositoryOrder;

        public OrderService()
        {
            _repositoryOrder = new RepositoryOrder();
        }

        public List<OrderShortModel> GetOrderssWithoutSensitiveData()
        {
            var orders = _repositoryOrder.GetAllOrders();
            return CustomMapper.GetInstance().Map<List<OrderShortModel>>(orders);
        }

        public List<OrderModel> GetPlayers()
        {
            var orders = _repositoryOrder.GetAllOrders();
            return CustomMapper.GetInstance().Map<List<OrderModel>>(orders);
        }
    }
}
