﻿using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class OpenChangeOrderWindowOfOrderInfoCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderDetailService _orderDetailService;
        private readonly ClientService _clientService;
        private readonly ProductService _productService;


        public OpenChangeOrderWindowOfOrderInfoCommand(TabItemOrdersViewModel viewModel, OrderDetailService orderDetailService, ClientService clientService, ProductService productService)
        {
            _viewModel = viewModel;
            _orderDetailService = orderDetailService;
            _clientService = clientService;
            _productService = productService;

        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Visible;
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangedDate = _viewModel.SelectedOrder.Date;
            _viewModel.ChangedAddressText = _viewModel.SelectedOrder.Address;
            _viewModel.Clients.Clear();
            var clientsActionResult = _clientService.GetAllClients();
            if (clientsActionResult.Success)
            {
                foreach (var client in clientsActionResult.Data)
                    _viewModel.Clients.Add(client);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }
            _viewModel.Products.Clear();
            var productsActionResult = _productService.GetAllProducts();
            if (productsActionResult.Success)
            {
                foreach (var product in productsActionResult.Data)
                {
                    _viewModel.Products.Add(product);
                }
            }
            _viewModel.SelectedChangeClient = _viewModel.SelectedOrder.Client;
            _viewModel.SelectedOrder.OrderDetails = _orderDetailService.GetOrderDetailsByOrderId(_viewModel.SelectedOrder.Id);
        }
    }
}
