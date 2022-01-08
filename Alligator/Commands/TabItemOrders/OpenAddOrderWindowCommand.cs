using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class OpenAddOrderWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private ClientService _clientService;
        //private ProductService _productService;

        public OpenAddOrderWindowCommand(TabItemOrdersViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.NewDate = DateTime.Now;
            _viewModel.NewOrder = new OrderModel() { Address = _viewModel.NewAddressText, Client = _viewModel.SelectedClient, Date = _viewModel.NewDate };
            _viewModel.Clients.Clear();
            if (_clientService.GetAllClients().Success is true)
            {
                var clients = _clientService.GetAllClients().Data;
                foreach (var client in clients)
                    _viewModel.Clients.Add(client);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }
            //пока нет productServic'а
            //foreach (var product in _productService.GetAllProducts())
            //{
            //    _viewModel.Products.Add(product);
            //}
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.AddOrderWindowVisibility = Visibility.Visible;         
        }
    }
}
