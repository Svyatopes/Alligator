using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class DeleteReviewWindowOfOrderInfoCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderReviewService _orderReviewService;

        public DeleteReviewWindowOfOrderInfoCommand(TabItemOrdersViewModel viewModel, OrderReviewService orderReviewService)
        {
            _viewModel = viewModel;
            _orderReviewService = orderReviewService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOrderReview is not null;
        }

        public override void Execute(object parameter)
        {
            _orderReviewService.DeleteOrderReviewModel(_viewModel.SelectedOrderReview.Id);
            _viewModel.OrderReviews.Remove(_viewModel.SelectedOrderReview);
        }
    }
}
