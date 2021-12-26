using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
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
           _orderReviewService.AddOrderReviewModel(newReview, _viewModel.SelectedOrderReview.Id);
            var newReviewModel = _orderReviewService.GetOrderReviewModelById(_viewModel.SelectedOrderReview.Id);
            _viewModel.OrderReviews.Add(newReviewModel);
            _viewModel.NewReviewText = string.Empty;
        }
    }
}
