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
            var ReviewToAdd = _viewModel.NewReviewText.Trim();

            if (string.IsNullOrEmpty(ReviewToAdd))
            {
                MessageBox.Show("Введите текст отзыва");
                return;
            }
           _orderReviewService.AddOrderReviewModel(ReviewToAdd, _viewModel.SelectedOrderReview.Id);

            //_viewModel.OrderReview.Add(ReviewToAdd);
            _viewModel.NewReviewText = string.Empty;
        }
    }
}
