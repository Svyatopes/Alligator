using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
{
    public class OrderReviewService
    {
        private readonly IOrderReviewRepository _repositoryOrderReview;

        public OrderReviewService(IOrderReviewRepository fakeRepositoryOrderReview)
        {
            _repositoryOrderReview = fakeRepositoryOrderReview;
        }

        public OrderReviewService()
        {
            _repositoryOrderReview = new OrderReviewRepository();
        }

        public OrderReviewModel GetOrderReviewModelById(int id)
        {
            var orderReview = _repositoryOrderReview.GetOrderReviewById(id);
            return CustomMapper.GetInstance().Map<OrderReviewModel>(orderReview);
        }

        public List<OrderReviewModel> GetOrderReviewModelsByOrderId(int id)
        {
            var orderReviews = _repositoryOrderReview.GetOrderReviewsByOrderId(id);
            return CustomMapper.GetInstance().Map<List<OrderReviewModel>>(orderReviews);
        }

        public void AddOrderReviewModel(string text, int orderId)
        {
            _repositoryOrderReview.AddOrderReview(text, orderId);
        }

        public void EditOrderReviewModel(int id, string text)
        {
            _repositoryOrderReview.EditOrderReview(id, text);
        }

        public void DeleteOrderReviewModel(int id)
        {
            _repositoryOrderReview.DeleteOrderReview(id);
        }

        public void DeleteOrderReviewModelByOrderId(int orderId)
        {
            _repositoryOrderReview.DeleteOrderReviewByOrderId(orderId);
        }
    }
}
