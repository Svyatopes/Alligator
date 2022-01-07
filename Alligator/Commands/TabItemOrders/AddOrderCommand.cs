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
        private ClientService _clientService;

        public AddOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService, ClientService clientService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _clientService = clientService;
        }

        public override void Execute(object parameter)
        {
            var clients = _clientService.GetAllClients();
            _viewModel.Clients = new ObservableCollection<ClientModel>(clients);

            var newAddress = _viewModel.NewAdressText.Trim();
            if (string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Введите адрес");
                _viewModel.NewAdressText = string.Empty;
            }           
            else           
            _viewModel.AllOrders.Add(_orderService.GetOrderByIdWithDetailsAndReviews
            (_orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress)));
        }
    }
}
