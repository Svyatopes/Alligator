using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _repositoryOrderDetail;

        public OrderDetailService(IOrderDetailRepository repositoryOrderDetail)
        {
            _repositoryOrderDetail = repositoryOrderDetail;
        }
        
        public OrderDetailService()
        {
            _repositoryOrderDetail = new OrderDetailRepository();
        }


        public OrderDetailModel GetOrderDetailById(int id)
        {
            var orderDetail = _repositoryOrderDetail.GetOrderDetailById(id);
            return CustomMapper.GetInstance().Map<OrderDetailModel>(orderDetail);
        }

        public List<OrderDetailModel> GetOrderDetailsByOrderId(int id)
        {
            var orderDetails = _repositoryOrderDetail.GetOrderDetailsByOrderId(id);
            return CustomMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }

        public List<OrderDetailModel> GetOrderDetailsByProductId(int id)
        {
            var orderDetails = _repositoryOrderDetail.GetOrderDetailsByProductId(id);
            return CustomMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }

        public void AddOrderDetailModel(int amount, int orderId, int productId)
        {
            _repositoryOrderDetail.AddOrderDetail(amount, orderId, productId);
        }

        public void EditOrderDetailModel(int id, int amount)
        {
            _repositoryOrderDetail.EditOrderDetail(id, amount);
        }
        
        public void DeleteOrderDetailModel(int id)
        {
            _repositoryOrderDetail.DeleteOrderDetail(id);
        }

        public void DeleteOrderDetailModelByOrderId(int orderId)
        {
            _repositoryOrderDetail.DeleteOrderDetailByOrderId(orderId);
        }

        public void DeleteOrderDetailByProductId(int id)
        {
            _repositoryOrderDetail.DeleteOrderDetailByProductId(id);
        }
    }
}
