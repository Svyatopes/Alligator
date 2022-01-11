using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class OpenAddOrderWindowCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly ProductService _productService;

        public OpenAddOrderWindowCommand(TabItemOrdersViewModel viewModel, ClientService clientService, ProductService productService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.NewDate = DateTime.Now;
            _viewModel.NewAmount = string.Empty;
            _viewModel.NewAddressText = string.Empty;
            _viewModel.NewOrderReviews.Clear();
            _viewModel.NewOrderDetails.Clear();
            _viewModel.NewOrder = new OrderModel() { Address = _viewModel.NewAddressText, Client = _viewModel.SelectedClient, Date = _viewModel.NewDate };
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
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.AddOrderWindowVisibility = Visibility.Visible;
        }
    }
}
