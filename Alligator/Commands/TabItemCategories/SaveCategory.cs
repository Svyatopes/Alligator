using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{

    public class SaveCategory : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly CategoryService _categoryService;

        public SaveCategory(TabItemCategoriesViewModel viewModel, CategoryService categoryService)
        {
            _viewModel = viewModel;
            _categoryService = categoryService;
        }

        public override void Execute(object parameter)
        {
            var newCategoryName = _viewModel.TextBoxCategoryEditText.Trim();
            if (newCategoryName != _viewModel.SelectedCategory.Name)
            {
                var updatedCategory = new CategoryModel { Id = _viewModel.SelectedCategory.Id, Name = newCategoryName };
                var isUpdated = _categoryService.UpdateCategory(updatedCategory);
                if (isUpdated)
                {
                    _viewModel.Categories.Remove(_viewModel.SelectedCategory);
                    _viewModel.Categories.Add(updatedCategory);
                }
                else
                {
                    MessageBox.Show("Ошибка при записи в базу данных, попробуйте позже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }


            _viewModel.MainGridVisibilty = Visibility.Visible;
            _viewModel.GridEditCategoryVisibility = Visibility.Collapsed;
        }
    }
}
