using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(int amount, int orderId, int productId);
        void DeleteOrderDetail(int id);
        void DeleteOrderDetailByProductId(int id);
        void DeleteOrderDetailByOrderId(int orderId);
        void EditOrderDetail(int id, int amount);
        OrderDetail GetOrderDetailById(int id);
        List<OrderDetail> GetOrderDetailsByOrderId(int id);
        List<OrderDetail> GetOrderDetailsByProductId(int id);
    }
}