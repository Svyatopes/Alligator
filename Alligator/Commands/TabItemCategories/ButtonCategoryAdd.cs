using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    internal class ButtonCategoryAdd : CommandBase
    {
        private TabItemCategoriesViewModel viewModel;

        public ButtonCategoryAdd(TabItemCategoriesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var categoryNameToAdd = viewModel.TextBoxNewCategoryText.Trim();

            if (string.IsNullOrEmpty(categoryNameToAdd))
            {
                MessageBox.Show("Введите название категории");
                return;
            }

            if (viewModel.Categories.Any(c => c.Name == categoryNameToAdd))
            {
                MessageBox.Show("Такая категория уже существует");
                return;
            }

            viewModel.Categories.Add(new CategoryViewModel() { Name = categoryNameToAdd });
            viewModel.TextBoxNewCategoryText = string.Empty;
        }
    }
}