﻿using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class DeleteOrderCommand : CommandBase
    {

        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderReviewService _orderReviewService;

        public DeleteOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService, OrderDetailService orderDetailService, OrderReviewService orderReviewService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _orderReviewService = orderReviewService;
            _orderDetailService = orderDetailService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedOrder is not null;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Удалить заказ?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                _orderReviewService.DeleteOrderReviewModelByOrderId(_viewModel.SelectedOrder.Id);
                _orderDetailService.DeleteOrderDetailModelByOrderId(_viewModel.SelectedOrder.Id);
                _orderService.DeleteOrderModel(_viewModel.SelectedOrder.Id);
                _viewModel.AllOrders.Remove(_viewModel.SelectedOrder);
                _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
                _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
                _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
                _viewModel.OrdersWindowVisibility = Visibility.Visible;
            }
        }
    }
}