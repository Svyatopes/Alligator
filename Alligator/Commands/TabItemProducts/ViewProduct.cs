using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    internal class ViewProduct : CommandBase
    {
        private TabItemProductsViewModel viewModel;
        
        public ViewProduct(TabItemProductsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.Selected != null)
            {
                
            }
            else
            {
                MessageBox.Show("Выберите товар", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
