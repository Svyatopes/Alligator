using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.Helpers;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    class AddProduct : CommandBase
    {
        private TabItemProductsViewModel _viewModel;
        private readonly ProductService _productService;
        public AddProduct(TabItemProductsViewModel viewModel, ProductService productService)
        {
            _viewModel = viewModel;
            _productService = productService;
        }
        public override void Execute(object parameter)
        {
            WorkWithClasses.TrimAllStringProperties(_viewModel.ProductToAdd);

            if (!_viewModel.ProductToAdd.IsValid())
            {
                MessageBox.Show("Вы ввели некорректные данные! Возможно название продукта слишком длинное");
                return;
            }

            if (_viewModel.ProductToAdd.Category == null)
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }

            var productModel = _viewModel.ProductToAdd.ConvertToProductModel();

            var productModelActionResult = _productService.AddProduct(productModel);
            if (!productModelActionResult.Success)
            {
                MessageBox.Show($"Ошибка при записи в базу данных\r\n{productModelActionResult.ErrorMessage}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.Products.Add(productModelActionResult.Data);
            
            _viewModel.VisibilityAddProduct = Visibility.Collapsed;
            _viewModel.VisibilityAllProducts = Visibility.Visible;
        }
    }
}
