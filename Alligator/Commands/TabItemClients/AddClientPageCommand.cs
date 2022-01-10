using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class AddClientPageCommand : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        public AddClientPageCommand(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AddClient = Visibility.Visible;
            _viewModel.AllClients = Visibility.Collapsed;

            _viewModel.NewClient = new BusinessLayer.ClientModel();
        }
    }
}
