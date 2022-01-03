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
    public class DeleteClient_ClientCardPage : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientService;
        private CommentService _commentService;
        public DeleteClient_ClientCardPage(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этого клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                _viewModel.AllClients = Visibility.Visible;
                _viewModel.ClientCardVisibility = Visibility.Collapsed;
                _commentService.DeleteCommentsByClientId(_viewModel.SelectedClient.Id);
                _clientService.DeleteClient(_viewModel.SelectedClient);
                _viewModel.Clients.Remove(_viewModel.SelectedClient);
            }
        }
    }
}
