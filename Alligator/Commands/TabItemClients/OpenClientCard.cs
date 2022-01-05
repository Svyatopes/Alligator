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
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient is not  null;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AllClients = Visibility.Collapsed;
            _viewModel.ClientCardVisibility = Visibility.Visible;
            if (_viewModel.EditableClient is not null)
            {
                _viewModel.EditableClient = _clientService.GetClientById(_viewModel.SelectedClient.Id);
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
