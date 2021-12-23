using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonDeleteClient_ClientCard : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        public ButtonDeleteClient_ClientCard(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.AllClients = Visibility.Visible;
            viewModel.ClientCard = Visibility.Collapsed;
            viewModel.Clients.Remove(viewModel.Selected);
        }
    }
}
