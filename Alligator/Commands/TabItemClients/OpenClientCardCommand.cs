using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class OpenClientCardCommand : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientService;
        private CommentService _commentService;
        private OrderService _orderService;
        public OpenClientCardCommand(TabItemClientsViewModel viewModel,ClientService clientService, CommentService commentService, OrderService orderService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
            _orderService = orderService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient is not  null;
        }
        public override void Execute(object parameter)
        {

            _viewModel.AllClients = Visibility.Collapsed;
            _viewModel.ClientCardVisibility = Visibility.Visible;
            if (_viewModel.SelectedClient is not null)
            {

                // _viewModel.Orders = new ObservableCollection<OrderModel>(_orderService.GetOrdersByClientId(_viewModel.SelectedClient.Id).Data);


                _viewModel.Orders.Clear();
                if (_orderService.GetOrdersByClientId(_viewModel.SelectedClient.Id).Success)
                {
                    var clients = _orderService.GetOrdersByClientId(_viewModel.SelectedClient.Id).Data;
                    foreach (var client in clients)
                        _viewModel.Orders.Add(client);
                }

                _viewModel.EditableClient = _clientService.GetClientById(_viewModel.SelectedClient.Id).Data;
                _viewModel.Comments = new ObservableCollection<CommentModel>(_viewModel.EditableClient.Comments);
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _viewModel.AllClients = Visibility.Visible;
                _viewModel.ClientCardVisibility = Visibility.Collapsed;

            }
        }
    }
}
