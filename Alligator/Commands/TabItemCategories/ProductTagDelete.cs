using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ProductTagDelete : CommandBase
    {
        private TabItemCategoriesViewModel viewModel;
        private ProductTagService _productTagService;


        public ProductTagDelete(TabItemCategoriesViewModel viewModel, ProductTagService productTagService)
        {
            this.viewModel = viewModel;
            _productTagService = productTagService;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот тэг?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                if (_productTagService.DeleteProductTag(viewModel.SelectedProductTag))
                    viewModel.ProductTags.Remove(viewModel.SelectedProductTag);
                else
                    MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
