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

        public List<OrderModel> GetOrders()
        {
            var orders = _repositoryOrder.GetAllOrders();
            return CustomMapper.GetInstance().Map<List<OrderModel>>(orders);
        }

        public List<OrderModel> GetOrdersByClientId(int id)
        {
            var orders = _repositoryOrder.GetOrdersByClientId(id);
            return CustomMapper.GetInstance().Map<List<OrderModel>>(orders);
        }

        public void AddOrderModel(DateTime date, int clientId, string address)
        {
             _repositoryOrder.AddOrder(date, clientId, address);            
        }

        public void DeleteOrderModel(int id)
        {
            _repositoryOrder.DeleteOrder(id);
        }

        public void EditOrderModel(DateTime date, int id, string address)
        {
            _repositoryOrder.EditOrder(date, id, address);
        }
    }
}
