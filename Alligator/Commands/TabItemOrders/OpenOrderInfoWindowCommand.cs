using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class OpenOrderInfoWindowCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderService _orderService;

        public OpenOrderInfoWindowCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOrder is not null;
        }

        public override void Execute(object parameter)
        {
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Visible;
            _viewModel.SelectedOrderDate = _viewModel.SelectedOrder.Date;
            _viewModel.SelectedOrderAddress = _viewModel.SelectedOrder.Address;
            _viewModel.SelectedOrderClient = _viewModel.SelectedOrder.Client;
            var order = _orderService.GetOrderByIdWithDetailsAndReviews(_viewModel.SelectedOrder.Id).Data;
            _viewModel.OrderReviews = new ObservableCollection<OrderReviewModel>(order.OrderReviews);
            _viewModel.OrderDetails = new ObservableCollection<OrderDetailModel>(order.OrderDetails);
        }
    }
}
