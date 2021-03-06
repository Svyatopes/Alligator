using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class CategoryDelete : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly CategoryService _categoryService;

        public CategoryDelete(TabItemCategoriesViewModel viewModel, CategoryService categoryService)
        {
            _viewModel = viewModel;
            _categoryService = categoryService;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить эту категорию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                if (_categoryService.DeleteCategory(_viewModel.SelectedCategory))
                    _viewModel.Categories.Remove(_viewModel.SelectedCategory);
                else
                    MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
