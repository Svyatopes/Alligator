using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class DeleteClientCommand : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        private readonly OrderService _orderService;
        private readonly OrderReviewService _orderReviewService;
        private readonly OrderDetailService _orderDetailService;

        public DeleteClientCommand(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService, OrderService orderService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
            _orderService = orderService;
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

                var userAnswer = MessageBox.Show("Вы правда хотите удалить этого клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (userAnswer == MessageBoxResult.Yes)
                {
                    if (_orderService.DeleteOrdersByClientId(_viewModel.SelectedClient.Id) is false)
                    {
                        MessageBox.Show("VIP клиент", "Невозможно удалить", MessageBoxButton.OK);
                        return;
                    }
                    if (_commentService.DeleteCommentsByClientId(_viewModel.SelectedClient.Id))

                    {
                        _clientService.DeleteClient(_viewModel.SelectedClient);
                        _viewModel.Clients.Remove(_viewModel.SelectedClient);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении клиента", "Ошибка", MessageBoxButton.OK);
                    }
                }
            }
        }
    }
}
