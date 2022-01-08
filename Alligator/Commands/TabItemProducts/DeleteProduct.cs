using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class DeleteProduct : CommandBase
    {
        private TabItemProductsViewModel viewModel;

        public DeleteProduct(TabItemProductsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот товар?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                viewModel.Products.Remove(viewModel.Selected);
        }
    }
}
