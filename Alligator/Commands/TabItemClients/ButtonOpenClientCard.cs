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
            if (viewModel.Selected is null)
            {
                MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                viewModel.AllClients = Visibility.Collapsed;
                viewModel.ClientCard = Visibility.Visible;
                viewModel.Comments = viewModel.Selected.Comments;
            }
        }
    }
}
