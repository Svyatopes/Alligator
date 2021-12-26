using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonDeleteClient_AllClients : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        private ClientService _clientService;
        public ButtonDeleteClient_AllClients(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            this.viewModel = viewModel;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
           

            _clientService.DeleteClient(viewModel.Selected.Id);
            viewModel.Clients.Remove(viewModel.Selected);
        }
    }
}
