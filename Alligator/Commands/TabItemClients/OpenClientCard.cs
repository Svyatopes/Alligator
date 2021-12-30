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
    public class OpenClientCard : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientService;
        private CommentService _commentService;
        public OpenClientCard(TabItemClientsViewModel viewModel,ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AllClients = Visibility.Collapsed;
            _viewModel.ClientCardVisibility = Visibility.Visible;

            _viewModel.EditableClient = _clientService.GetClientById(_viewModel.SelectedClient.Id);
            _viewModel.EditableClient = _viewModel.SelectedClient;
            _viewModel.Comments = new ObservableCollection<CommentModel>(_viewModel.SelectedClient.Comments);
            _viewModel.Comments = new ObservableCollection<CommentModel>(_viewModel.EditableClient.Comments);
            _viewModel.SelectedClient.Comments.Clear();
            foreach (var item in _commentService.GetAllComments(_viewModel.SelectedClient.Id))
            {
                _viewModel.Comments.Add(item);
            }
        }
    }
}
