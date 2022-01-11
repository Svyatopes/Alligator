using Alligator.BusinessLayer.Services;
using Alligator.UI.Helpers;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class SaveChanges : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        public SaveChanges(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _commentService = commentService;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
            bool canExecute = ClientValidation.TrimAndCheckIsValid(_viewModel.EditableClient);
            if (!canExecute)
            {
                var userAnswer = MessageBox.Show("Корректно ли введены данные? ", "Проверь ну", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (userAnswer == MessageBoxResult.No)
                {
                    return;
                }
            }
            _clientService.UpdateClient(_viewModel.EditableClient);
            _viewModel.Clients.Clear();
            foreach (var item in _clientService.GetAllClients().Data)
            {
                _viewModel.Clients.Add(item);
            }

            _viewModel.AllClients = Visibility.Visible;
            _viewModel.ClientCardVisibility = Visibility.Collapsed;
            _viewModel.SelectedClient = _viewModel.EditableClient;

        }
    }
}
