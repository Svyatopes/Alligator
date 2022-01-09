using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ProductTagAdd : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly ProductTagService _productTagService;

        public ProductTagAdd(TabItemCategoriesViewModel viewModel, ProductTagService productTagService)
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

            var productTagActionResult = _productTagService.AddProductTag(productTagNameToAdd);
            if (!productTagActionResult.Success)
            {
                MessageBox.Show($"Ошибка при записи в базу данных\r\n{productTagActionResult.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.ProductTags.Add(productTagActionResult.Data);
            _viewModel.TextBoxNewProductTagText = string.Empty;
        }
    }
}
