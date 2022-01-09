using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class CategoryAdd : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly CategoryService _categoryService;

        public CategoryAdd(TabItemCategoriesViewModel viewModel, CategoryService categoryService)
        {
            _viewModel = viewModel;
            _categoryService = categoryService;
        }

        public override void Execute(object parameter)
        {
            var categoryNameToAdd = _viewModel.TextBoxNewCategoryText.Trim();

            if (string.IsNullOrEmpty(categoryNameToAdd))
            {
                MessageBox.Show("Введите название категории");
                return;
            }

            if (_viewModel.Categories.Any(c => c.Name == categoryNameToAdd))
            {
                MessageBox.Show("Такая категория уже существует");
                return;
            }

            var categoryActionResult = _categoryService.AddCategory(categoryNameToAdd);
            if (!categoryActionResult.Success)
            {
                MessageBox.Show($"Ошибка при записи в базу данных\r\n{categoryActionResult.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            _viewModel.Categories.Add(categoryActionResult.Data);
            _viewModel.TextBoxNewCategoryText = string.Empty;
        }
    }
}