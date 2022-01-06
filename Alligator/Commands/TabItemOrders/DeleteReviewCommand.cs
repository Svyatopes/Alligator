using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemOrders
{
    class DeleteReviewCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderReviewService _orderReviewService;

        public DeleteReviewCommand(TabItemOrdersViewModel viewModel, OrderReviewService orderReviewService)
        {
            _viewModel = viewModel;
            _orderReviewService = orderReviewService;
        }
        public override void Execute(object parameter)
        {
            _orderReviewService.DeleteOrderReviewModel(_viewModel.SelectedOrderReview.Id);
            _viewModel.OrderReviews.Remove(_viewModel.SelectedOrderReview);
        }
    }
}
