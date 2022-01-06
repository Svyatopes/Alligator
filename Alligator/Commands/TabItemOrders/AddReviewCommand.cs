using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
   internal class AddReviewCommand: CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderReviewService _orderReviewService;

        public AddReviewCommand(TabItemOrdersViewModel viewModel, OrderReviewService orderReviewService)
        {
            _viewModel = viewModel;
            _orderReviewService = orderReviewService;
        }

        public override void Execute(object parameter)
        {
            var newReview = _viewModel.NewReviewText.Trim();

            if (string.IsNullOrEmpty(newReview))
            {
                MessageBox.Show("Введите текст отзыва");
                return;
            }
            
            if (_viewModel.SelectedOrder.OrderReviews is null)
            {
                List<OrderReviewModel> orderReviews = new List<OrderReviewModel>();
                
                _viewModel.SelectedOrder.OrderReviews=orderReviews;
            }
            
            if (_viewModel.OrderReviews is null)
            {
                ObservableCollection<OrderReviewModel> orderReviews = new ObservableCollection<OrderReviewModel>();

                _viewModel.OrderReviews = orderReviews;
            }

            var newOrderReview = new OrderReviewModel() {Order=_viewModel.SelectedOrder, Text=newReview };
            _viewModel.OrderReviews.Add(newOrderReview);
            _orderReviewService.AddOrderReviewModel(newReview, _viewModel.SelectedOrder.Id);           
            _viewModel.NewReviewText = string.Empty;

        }
    }
}
