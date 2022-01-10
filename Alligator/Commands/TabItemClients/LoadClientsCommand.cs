using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class LoadClientsCommand : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;

        public LoadClientsCommand(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Clients.Clear();
            if(_clientService.GetAllClients().Success is true)
            {
                var clients = _clientService.GetAllClients().Data;
                foreach (var client in clients)
                _viewModel.Clients.Add(client);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }
           
           
            
        }

    }
}
