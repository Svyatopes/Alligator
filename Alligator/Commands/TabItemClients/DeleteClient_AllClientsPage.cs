using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class DeleteClient_AllClientsPage : CommandBase
    {
        private readonly TabItemClientsViewModel viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        public DeleteClient_AllClientsPage(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            this.viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.SelectedClient is null)
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
                    _commentService.DeleteCommentsByClientId(viewModel.SelectedClient.Id);
                    _clientService.DeleteClient(viewModel.SelectedClient);
                    viewModel.Clients.Remove(viewModel.SelectedClient);
                }
            }
        }
    }
}
