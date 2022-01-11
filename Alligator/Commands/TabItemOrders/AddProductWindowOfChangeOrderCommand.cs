using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    class AddProductWindowOfChangeOrderCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderDetailService _orderDetailService;
        public AddProductWindowOfChangeOrderCommand(TabItemOrdersViewModel viewModel, OrderDetailService orderDetailService)
        {
            _viewModel = viewModel;
            _orderDetailService = orderDetailService;
        }

        public override void Execute(object parameter)
        {
            var newAmount = _viewModel.NewAmount;
            if (!int.TryParse(newAmount, out _) || string.IsNullOrEmpty(newAmount))
            {
                MessageBox.Show("Введите количество продуктов");
                return;
            }
            int amount = Convert.ToInt32(newAmount);

            if (_viewModel.SelectedProduct is null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            if (_viewModel.SelectedOrder.OrderDetails is null)
            {
                List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

                _viewModel.SelectedOrder.OrderDetails = orderDetails;
            }
            if (_viewModel.OrderDetails is null)
            {
                _viewModel.OrderDetails = new ObservableCollection<OrderDetailModel>();
            }

            var orderDetail = new OrderDetailModel() { Product = _viewModel.SelectedProduct, Amount = amount, Order = _viewModel.SelectedOrder };
            _viewModel.SelectedOrder.OrderDetails.Add(orderDetail);
            _viewModel.OrderDetails.Add(orderDetail);
            _orderDetailService.AddOrderDetailModel(amount, _viewModel.SelectedOrder.Id, _viewModel.SelectedProduct.Id);
        }
    }

}

