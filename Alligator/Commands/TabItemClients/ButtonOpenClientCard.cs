using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonOpenClientCard : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        public ButtonOpenClientCard(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.AllClients = Visibility.Collapsed;
            viewModel.ClientCard = Visibility.Visible;
        }
    }
}
