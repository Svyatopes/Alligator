using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class OpenProductCard : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        private readonly ProductService _productService;

        public OpenProductCard(TabItemProductsViewModel viewModel, ProductService productService)
        {
            _viewModel = viewModel;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            var productModelActionResult = _productService.GetProductById(_viewModel.SelectedProduct.Id);
            if (!productModelActionResult.Success)
            {
                MessageBox.Show($"Ошибка при обращении к базе данных\r\n{productModelActionResult.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.ProductToEdit = new ViewModels.EntitiesViewModels.ProductViewModel(productModelActionResult.Data);

            _viewModel.VisibilityEditProduct = Visibility.Visible;
            _viewModel.VisibilityAllProducts = Visibility.Collapsed;
        }
    }
}
