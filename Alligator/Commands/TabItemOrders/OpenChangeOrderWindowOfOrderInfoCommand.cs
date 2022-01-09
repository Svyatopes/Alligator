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
    public class OpenChangeOrderWindowOfOrderInfoCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;
        private OrderDetailService _orderDetailService;
        private OrderReviewService _orderReviewService;
        private ClientService _clientService;
        //private ProductService _productService;


        public OpenChangeOrderWindowOfOrderInfoCommand(TabItemOrdersViewModel viewModel, OrderService orderService, OrderDetailService orderDetailService, OrderReviewService orderReviewService, ClientService clientService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _orderReviewService = orderReviewService;
            _orderDetailService = orderDetailService;
            _clientService = clientService;
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
            _viewModel.SelectedChangeClient = _viewModel.SelectedOrder.Client;
            //пока нет productServic'а
            //foreach (var product in _productService.GetAllProducts())
            //{
            //    _viewModel.Products.Add(product);
            //}
        }
    }
}
