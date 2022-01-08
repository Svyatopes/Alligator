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
            _viewModel.Clients.Clear();
            foreach (var client in _clientService.GetAllClients())
            {
                _viewModel.Clients.Add(client);
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
