using Alligator.BusinessLayer;
using Alligator.UI.Helpers;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class SaveChanges : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        private readonly ProductService _productService;

        public SaveChanges(TabItemProductsViewModel viewModel, ProductService productService)
        {
            _viewModel = viewModel;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            WorkWithClasses.TrimAllStringProperties(_viewModel.ProductToEdit);

            if (!_viewModel.ProductToEdit.IsValid())
            {
                MessageBox.Show("Вы ввели некорректные данные! Возможно название продукта слишком длинное");
                return;
            }

            if (_viewModel.ProductToEdit.Category == null)
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }

            var productModel = _viewModel.ProductToEdit.ConvertToProductModel();


            var productModelActionResult = _productService.UpdateProduct(productModel);
            if (!productModelActionResult.Success)
            {
                MessageBox.Show($"Ошибка при записи в базу данных\r\n{productModelActionResult.ErrorMessage}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.Products.Remove(_viewModel.SelectedProduct);
            _viewModel.Products.Add(productModelActionResult.Data);

            _viewModel.VisibilityEditProduct = Visibility.Collapsed;
            _viewModel.VisibilityAllProducts = Visibility.Visible;
        }
    }
}