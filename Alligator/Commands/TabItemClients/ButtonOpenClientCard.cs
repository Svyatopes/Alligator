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
    public class ButtonOpenClientCard : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientService;
        public ButtonOpenClientCard(TabItemClientsViewModel viewModel,ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AllClients = Visibility.Collapsed;
            _viewModel.ClientCardVisibility = Visibility.Visible;

            _viewModel.EditableClient = _clientService.GetClientById(_viewModel.SelectedClient.Id);
            _viewModel.Comments = new ObservableCollection<CommentModel>(_viewModel.EditableClient.Comments);

        }
    }
}
