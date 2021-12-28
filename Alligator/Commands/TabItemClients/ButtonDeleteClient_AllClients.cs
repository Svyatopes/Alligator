using Alligator.BusinessLayer;
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
    public class ButtonDeleteClient_AllClients : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        private ClientService _clientService;
        private CommentService _commentService;
        public ButtonDeleteClient_AllClients(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            this.viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.Selected is null)
            {
                MessageBox.Show("Выберите клиента", "Удаление клиента", MessageBoxButton.OK);
            }
            else
            {
                _commentService.DeleteCommentsByClientId(viewModel.Selected.Id);
                _clientService.DeleteClient(viewModel.Selected);
                viewModel.Clients.Remove(viewModel.Selected);
            }
        }
    }
}
