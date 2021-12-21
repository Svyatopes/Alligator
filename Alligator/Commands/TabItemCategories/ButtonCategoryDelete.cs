using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ButtonCategoryDelete : CommandBase
    {
        private TabItemCategoriesViewModel viewModel;

        public ButtonCategoryDelete(TabItemCategoriesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить эту категорию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                viewModel.Categories.Remove(viewModel.SelectedCategory);
        }
    }
}
