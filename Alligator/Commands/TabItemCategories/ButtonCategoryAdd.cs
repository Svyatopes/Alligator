using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    internal class ButtonCategoryAdd : CommandBase
    {
        private TabItemCategoriesViewModel _viewModel;
        private CategoryService _categoryService;

        public ButtonCategoryAdd(TabItemCategoriesViewModel viewModel, CategoryService categoryService)
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

            var category = _categoryService.AddCategory(categoryNameToAdd);
            if (category == null)
            {
                MessageBox.Show("Ошибка при записи в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _viewModel.Categories.Add(category);
            _viewModel.TextBoxNewCategoryText = string.Empty;
        }
    }
}