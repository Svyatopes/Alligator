using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class DeleteSupply_AllSupplies: CommandBase
    {
        private TabItemSuppliesViewModel viewModel;


        public DeleteSupply_AllSupplies(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить поставку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                viewModel.Supplies.Remove(viewModel.Selected);
        }
    }
}
