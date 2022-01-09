using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ProductTagDelete : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly ProductTagService _productTagService;


        public ProductTagDelete(TabItemCategoriesViewModel viewModel, ProductTagService productTagService)
        {
            this._viewModel = viewModel;
            _productTagService = productTagService;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот тэг?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                if (_productTagService.DeleteProductTag(_viewModel.SelectedProductTag))
                    _viewModel.ProductTags.Remove(_viewModel.SelectedProductTag);
                else
                    MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
