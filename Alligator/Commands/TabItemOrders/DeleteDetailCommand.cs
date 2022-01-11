using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemOrders
{
    class DeleteDetailCommand : CommandBase
    {

        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderDetailService _orderDetailService;


        public DeleteDetailCommand(TabItemOrdersViewModel viewModel, OrderDetailService orderDetailService)
        {
            _viewModel = viewModel;
            _orderDetailService = orderDetailService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOrderDetail is not null;
        }

        public override void Execute(object parameter)
        {
            _orderDetailService.DeleteOrderDetailModel(_viewModel.SelectedOrderDetail.Id);
            _viewModel.OrderDetails.Remove(_viewModel.SelectedOrderDetail);
        }



    }
}
