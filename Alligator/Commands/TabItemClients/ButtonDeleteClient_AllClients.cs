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
        public ButtonDeleteClient_AllClients(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.Clients.Remove(viewModel.Selected);
        }
    }
}
