using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ButtonProductTagAdd : CommandBase
    {
        private TabItemCategoriesViewModel viewModel;

        public ButtonProductTagAdd(TabItemCategoriesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var productTagNameToAdd = viewModel.TextBoxNewProductTagText.Trim();

            if (string.IsNullOrEmpty(productTagNameToAdd))
            {
                MessageBox.Show("Введите название тэга");
                return;
            }

            if (viewModel.ProductTags.Any(pt => pt.Name == productTagNameToAdd))
            {
                MessageBox.Show("Такой тэг уже существует");
                return;
            }

            //TODO: use business logic with adding
            viewModel.ProductTags.Add(new ProductTagViewModel() { Name = productTagNameToAdd });
            viewModel.TextBoxNewProductTagText = string.Empty;
        }
    }
}
