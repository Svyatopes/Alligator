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
        private readonly OrderDetailRepository _repositoryOrderdetail;

        public OrderDetailService()
        {
            _repositoryOrderdetail = new OrderDetailRepository();
        }

        public OrderDetailModel GetOrderDetailById(int id)
        {
            var orderDetail = _repositoryOrderdetail.GetOrderDetailById(id);
            return OrderMapper.GetInstance().Map<OrderDetailModel>(orderDetail);
        }

        public List<OrderDetailModel> GetOrderDetailsByOrderId(int id)
        {
            var orderDetails = _repositoryOrderdetail.GetOrderDetailsByOrderId(id);
            return OrderMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }

        public List<OrderDetailModel> GetOrderDetailsByProductId(int id)
        {
            var orderDetails = _repositoryOrderdetail.GetOrderDetailsByProductId(id);
            return OrderMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }

        public void AddOrderDetailModel(int amount, int orderId, int productId)
        {
            _repositoryOrderdetail.AddOrderDetail(amount, orderId, productId);
        }

        public void EditOrderDetailModel(int id, int amount)
        {
            _repositoryOrderdetail.EditOrderDetail(id, amount);
        }
        
        public void DeleteOrderDetailModel(int id)
        {
            _repositoryOrderdetail.DeleteOrderDetail(id);
        }

        public void DeleteOrderDetailByProductId(int id)
        {
            _repositoryOrderdetail.DeleteOrderDetailByProductId(id);
        }
    }
}
