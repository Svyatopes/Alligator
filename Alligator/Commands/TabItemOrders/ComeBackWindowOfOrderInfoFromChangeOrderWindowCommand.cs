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
    class ComeBackWindowOfOrderInfoFromChangeOrderWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public ComeBackWindowOfOrderInfoFromChangeOrderWindowCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Visible;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            if (_orderService.GetOrderByIdWithDetailsAndReviews(_viewModel.SelectedOrder.Id).Success is true)
            {
                var ordersWithDetailsAndReviews = _orderService.GetOrderByIdWithDetailsAndReviews(_viewModel.SelectedOrder.Id).Data;
                _viewModel.OrderReviews = new ObservableCollection<OrderReviewModel>(ordersWithDetailsAndReviews.OrderReviews);
                _viewModel.OrderDetails = new ObservableCollection<OrderDetailModel>(ordersWithDetailsAndReviews.OrderDetails);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }           
            _viewModel.SelectedOrderDate = _viewModel.SelectedOrder.Date;
            _viewModel.SelectedOrderAddress = _viewModel.SelectedOrder.Address;
            _viewModel.SelectedOrderClient.FirstName = _viewModel.SelectedOrder.Client.FirstName;
        }    
    }
}
