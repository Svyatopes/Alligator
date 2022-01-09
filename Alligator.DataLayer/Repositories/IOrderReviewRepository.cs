using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IOrderReviewRepository
    {
        void AddOrderReview(string text, int orderId);
        void DeleteOrderReview(int id);
        void DeleteOrderReviewByOrderId(int orderId);
        void EditOrderReview(int id, string text);
        OrderReview GetOrderReviewById(int id);
        List<OrderReview> GetOrderReviewsByOrderId(int id);
    }
}