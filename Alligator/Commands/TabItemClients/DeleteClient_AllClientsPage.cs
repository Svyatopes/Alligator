using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class DeleteClient_AllClientsPage : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        public DeleteClient_AllClientsPage(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedClient is not null;
        }
        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedClient is null)
            {
                MessageBox.Show("Выберите клиента", "Удаление клиента", MessageBoxButton.OK);
            }
            else
            {
                
                //TODO: сделать работу с базой через try catch
                //TODO: отлавливать ошибки, если вдруг есть связи и нельзя удалить клиента()(())(
                var userAnswer = MessageBox.Show("Вы правда хотите удалить этого клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (userAnswer == MessageBoxResult.Yes)
                {
                    if (_commentService.DeleteCommentsByClientId(_viewModel.SelectedClient.Id) &&
                    _clientService.DeleteClient(_viewModel.SelectedClient))
                    {
                        _viewModel.Clients.Remove(_viewModel.SelectedClient);
                    }
                }
            }
        }
    }
}
