using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class DeleteProductInSupply : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;


        public DeleteProductInSupply(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить продукт?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                viewModel.SupplyDetails.Remove(viewModel.PSelected);
        }
    }
}

