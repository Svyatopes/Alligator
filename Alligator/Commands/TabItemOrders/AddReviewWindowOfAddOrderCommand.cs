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

            if (_viewModel.OrderReviews is null)
            {
                ObservableCollection<OrderReviewModel> orderReviews = new ObservableCollection<OrderReviewModel>();

                _viewModel.NewOrderReviews = orderReviews;
            }

            var newOrderReview = new OrderReviewModel() { Text = newReview };
            _viewModel.NewOrderReviews.Add(newOrderReview);          
            _viewModel.NewReviewText = string.Empty;
        }
    }    
}
