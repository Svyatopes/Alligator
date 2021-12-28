using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;

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
            foreach (var client in _clientService.GetAllClients())
                _viewModel.Clients.Add(client);


        }

    }
}
