using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonDeleteClient_ClientCard : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientService;
        private CommentService _commentService;
        public ButtonDeleteClient_ClientCard(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AllClients = Visibility.Visible;
            _viewModel.ClientCard = Visibility.Collapsed;
            _commentService.DeleteCommentsByClientId(_viewModel.Selected.Id);
            _clientService.DeleteClient(_viewModel.Selected);
            _viewModel.Clients.Remove(_viewModel.Selected);
        }
    }
}
