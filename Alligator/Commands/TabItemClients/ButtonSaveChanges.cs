using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonSaveChanges : CommandBase
    {
        private readonly TabItemClientsViewModel viewModel;
        public ButtonSaveChanges(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.AllClients = Visibility.Visible;
            viewModel.ClientCard = Visibility.Collapsed;
        }
    }
}
