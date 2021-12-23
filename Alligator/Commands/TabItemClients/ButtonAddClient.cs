using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonAddClient : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        public ButtonAddClient(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.Selected == null)
            {
                
                
            }
            else
            {
                MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            viewModel.Selected = null;
        }
    }
}
