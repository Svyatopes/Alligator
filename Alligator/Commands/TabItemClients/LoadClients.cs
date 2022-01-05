using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class LoadClients : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;

        public LoadClients(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Clients.Clear();
            var clients = _clientService.GetAllClients();
            foreach (var client in _clientService.GetAllClients())
            _viewModel.Clients.Add(client);

        }

    }
}
