using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class LoadProducts : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly ProductTagService _productTagService;

        public LoadProducts(TabItemProductsViewModel viewModel, ProductService productService, CategoryService categoryService,
                            ProductTagService productTagService)
        {
            _viewModel = viewModel;
            _productService = productService;
            _categoryService = categoryService;
            _productTagService = productTagService;
        }

        public override void Execute(object parameter)
        {
            var productsActionResult = _productService.GetAllProducts();
            if (productsActionResult.Success)
            {
                _viewModel.Products.Clear();
                foreach (var product in productsActionResult.Data)
                {
                    _viewModel.Products.Add(product);
                }
            }

            var categoriesActionResult = _categoryService.GetAllCategories();
            if (categoriesActionResult.Success)
            {
                _viewModel.Categories.Clear();
                foreach (var category in categoriesActionResult.Data)
                {
                    _viewModel.Categories.Add(category);
                }
            }

            var productTagsActionResult = _productTagService.GetAllProductTags();
            if(productTagsActionResult.Success)
            {
                _viewModel.ProductTags.Clear();
                foreach(var productTag in productTagsActionResult.Data)
                {
                    _viewModel.ProductTags.Add(productTag);
                }
            }
        }
    }
}
