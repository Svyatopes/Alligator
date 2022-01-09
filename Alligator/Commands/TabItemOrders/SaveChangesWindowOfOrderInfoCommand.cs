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
    public class SaveChangesWindowOfOrderInfoCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;
        private OrderDetailService _orderDetailService;
        private OrderReviewService _orderReviewService;

        public SaveChangesWindowOfOrderInfoCommand(TabItemOrdersViewModel viewModel, OrderService orderService, OrderDetailService orderDetailService, OrderReviewService orderReviewService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _orderReviewService = orderReviewService;
            _orderDetailService = orderDetailService;
        }

        public override void Execute(object parameter)
        {
            _orderService.EditOrderModel(_viewModel.SelectedOrder.Date, _viewModel.SelectedOrder.Id, _viewModel.SelectedOrder.Address);
            _orderDetailService.EditOrderDetailModel(_viewModel.SelectedOrderDetail.Id, _viewModel.SelectedOrderDetail.Amount);
            _orderReviewService.EditOrderReviewModel(_viewModel.SelectedOrderReview.Id, _viewModel.SelectedOrderReview.Text);
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Visible;
        }
    }
}
