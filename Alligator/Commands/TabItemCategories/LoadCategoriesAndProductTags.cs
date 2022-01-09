using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;

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
            var categosriesActionResult = _categoryService.GetAllCategories();
            if (categosriesActionResult.Success)
            {
                foreach (var category in categosriesActionResult.Data)
                    _viewModel.Categories.Add(category);
            }

            _viewModel.ProductTags.Clear();
            var productTagsActionResult = _productTagService.GetAllProductTags();
            if (productTagsActionResult.Success)
            {
                foreach (var productTag in productTagsActionResult.Data)
                    _viewModel.ProductTags.Add(productTag);
            }
        }

    }
}
