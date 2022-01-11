using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class DeleteProduct : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        private readonly ProductService _productService;

        public DeleteProduct(TabItemProductsViewModel viewModel, ProductService productService)
        {
            _viewModel = viewModel;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот товар?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                var deleted = _productService.DeleteProduct(_viewModel.SelectedProduct);
                if (!deleted)
                {
                    MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _viewModel.Products.Remove(_viewModel.SelectedProduct);
            }
        }
    }
}
