using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
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

        public OrderService(IOrderRepository fakeRepositoryOrder, IOrderDetailRepository fakeRepositoryOrderDetail, IOrderReviewRepository fakeRepositoryOrderReview)
        {
            _repositoryOrder = fakeRepositoryOrder;
            _repositoryOrderDetail = fakeRepositoryOrderDetail;
            _repositoryOrderReview = fakeRepositoryOrderReview;
        }

        public OrderService()
        {
            _repositoryOrder = new OrderRepository();
            _repositoryOrderDetail = new OrderDetailRepository();
            _repositoryOrderReview = new OrderReviewRepository();
        }

        public ActionResult<List<OrderModel>> GetOrders()
        {
            var orders = _repositoryOrder.GetAllOrders();
            try
            {
                return new ActionResult<List<OrderModel>>(true, CustomMapper.GetInstance().Map<List<OrderModel>>(orders));
            }
            catch (Exception exception)
            {
                return new ActionResult<List<OrderModel>>(false, null) { ErrorMessage = exception.Message };
            }
        }

        public ActionResult<List<OrderModel>> GetOrdersByClientId(int id)
        {
            var orders = _repositoryOrder.GetOrdersByClientId(id);
            try
            {
                return new ActionResult<List<OrderModel>>(true, CustomMapper.GetInstance().Map<List<OrderModel>>(orders));
            }
            catch (Exception exception)
            {
                return new ActionResult<List<OrderModel>>(false, null) { ErrorMessage = exception.Message };
            }
        }

        public ActionResult<OrderModel> GetOrderByIdWithDetailsAndReviews(int id)
        {
            var order = _repositoryOrder.GetOrderById(id);
            order.OrderDetails = _repositoryOrderDetail.GetOrderDetailsByOrderId(id);
            order.OrderReviews = _repositoryOrderReview.GetOrderReviewsByOrderId(id);
            try
            {
                return new ActionResult<OrderModel>(true, CustomMapper.GetInstance().Map<OrderModel>(order));
            }
            catch
            (Exception exception)
            {
                return new ActionResult<OrderModel>(false, null) { ErrorMessage = exception.Message };
                
            }
        }

        public int AddOrderModel(DateTime date, int clientId, string address)
        {           
            try
            {
              int id =_repositoryOrder.AddOrder(date, clientId, address);
              return id;
            }
            catch
            {
                return -1;
            }
        }

        public bool DeleteOrderModel(int id)
        {
            try
            {
                _repositoryOrder.DeleteOrder(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditOrderModel(OrderModel editedOrder)
        {
            var order = CustomMapper.GetInstance().Map<Order>(editedOrder);
            try
            {
              _repositoryOrder.EditOrder(order);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
