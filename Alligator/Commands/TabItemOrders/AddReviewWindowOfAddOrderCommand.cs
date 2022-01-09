using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
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
    class AddReviewWindowOfAddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;       

        public AddReviewWindowOfAddOrderCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var newReview = _viewModel.NewReviewText.Trim();

            if (string.IsNullOrEmpty(newReview))
            {
                MessageBox.Show("Введите текст отзыва");
                return;
            }
            
            if (_viewModel.NewOrder.OrderReviews is null)
            {
                List<OrderReviewModel> orderReviews = new List<OrderReviewModel>();

                _viewModel.NewOrder.OrderReviews = orderReviews;
            }
            if (_viewModel.NewOrderReviews is null)
            {
               
                _viewModel.NewOrderReviews = new ObservableCollection<OrderReviewModel>();

            }

            var newOrderReview = new OrderReviewModel() { Order=_viewModel.NewOrder, Text = newReview };
            _viewModel.NewOrder.OrderReviews.Add(newOrderReview);
            _viewModel.NewOrderReviews.Add(newOrderReview);          
            _viewModel.NewReviewText = string.Empty;
        }
    }    
}
