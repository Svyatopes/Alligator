using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ButtonProductTagAdd : CommandBase
    {
        private TabItemCategoriesViewModel _viewModel;
        private ProductTagService _productTagService;

        public ButtonProductTagAdd(TabItemCategoriesViewModel viewModel, ProductTagService productTagService)
        {
            _viewModel = viewModel;
            _productTagService = productTagService;
        }

        public override void Execute(object parameter)
        {
            var productTagNameToAdd = _viewModel.TextBoxNewProductTagText.Trim();

            if (string.IsNullOrEmpty(productTagNameToAdd))
            {
                MessageBox.Show("Введите название тэга");
                return;
            }

            if (_viewModel.ProductTags.Any(pt => pt.Name == productTagNameToAdd))
            {
                MessageBox.Show("Такой тэг уже существует");
                return;
            }

            var productTag = _productTagService.AddProductTag(productTagNameToAdd);
            if (productTag == null)
            {
                MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.ProductTags.Add(productTag);
            _viewModel.TextBoxNewProductTagText = string.Empty;
        }
    }
}
