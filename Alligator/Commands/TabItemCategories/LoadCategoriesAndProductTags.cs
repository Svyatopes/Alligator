using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Collections.ObjectModel;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class LoadCategoriesAndProductTags : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly ProductTagService _productTagService;
        private readonly CategoryService _categoryService;

        public LoadCategoriesAndProductTags(TabItemCategoriesViewModel viewModel, ProductTagService productTagService, CategoryService categoryService)
        {
            _viewModel = viewModel;
            _productTagService = productTagService;
            _categoryService = categoryService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Categories.Clear();
            foreach (var category in _categoryService.GetAllCategories())
                _viewModel.Categories.Add(category);

            _viewModel.ProductTags.Clear();
            foreach (var productTag in _productTagService.GetAllProductTags())
                _viewModel.ProductTags.Add(productTag);
        }

    }
}
