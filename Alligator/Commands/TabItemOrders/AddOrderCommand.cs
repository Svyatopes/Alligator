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
    public class AddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;
        private OrderReviewService _orderReviewService;
        private OrderDetailService _orderDetailService;

        public AddOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService, OrderReviewService orderReviewService
        , OrderDetailService orderDetailService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _orderReviewService = orderReviewService;
            _orderDetailService = orderDetailService;
        }

        public override void Execute(object parameter)
        {
            var newAddress = _viewModel.NewAddressText;
            if (string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Введите адрес");
                _viewModel.NewAddressText = string.Empty;
            }
            newAddress = _viewModel.NewAddressText.Trim();
            if (_viewModel.SelectedClient is null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            } 
            if (_viewModel.NewOrder.OrderDetails.Count==0)
            {
                MessageBox.Show("Выберите продукты и их количество");
                return;
            }
           int orderId = _orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress);             
            foreach (var orderReview in _viewModel.NewOrderReviews)
            {
                _orderReviewService.AddOrderReviewModel(orderReview.Text, orderId);
            }
            foreach (var orderDetail in _viewModel.NewOrderDetails)
            {
                _orderDetailService.AddOrderDetailModel(orderDetail.Amount, orderId, orderDetail.Product.Id);
            }
            _viewModel.AllOrders.Add(_orderService.GetOrderByIdWithDetailsAndReviews(orderId));
        }
    }
}
