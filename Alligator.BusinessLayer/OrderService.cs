using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class OrderService 
    {
        private readonly IOrderRepository _repositoryOrder;
        private readonly IOrderDetailRepository _repositoryOrderDetail;
        private readonly IOrderReviewRepository _repositoryOrderReview;

        public OrderService(IOrderRepository repositoryOrder, IOrderDetailRepository repositoryOrderDetail, IOrderReviewRepository repositoryOrderReview)
        {
            _repositoryOrder = repositoryOrder;
            _repositoryOrderDetail = repositoryOrderDetail;
            _repositoryOrderReview = repositoryOrderReview;
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

        public OrderModel GetOrderByIdWithDetailsAndReviews(int id)
        {
            var order = _repositoryOrder.GetOrderById(id);
            order.OrderDetails = _repositoryOrderDetail.GetOrderDetailsByOrderId(id);
            order.OrderReviews = _repositoryOrderReview.GetOrderReviewsByOrderId(id);
            return CustomMapper.GetInstance().Map<OrderModel>(order);
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
