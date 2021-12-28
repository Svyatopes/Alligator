using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public class LoadClientsAndComments : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;

        public LoadClientsAndComments(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
            _commentService = commentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Clients.Clear();
            foreach (var client in _clientService.GetAllClients())
                _viewModel.Clients.Add(client);


        }

    }
}
