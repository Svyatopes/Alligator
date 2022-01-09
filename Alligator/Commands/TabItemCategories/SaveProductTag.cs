using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{

    public class SaveProductTag : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;
        private readonly ProductTagService _productTagService;

        public SaveProductTag(TabItemCategoriesViewModel viewModel, ProductTagService productTagService)
        {
            _viewModel = viewModel;
            _productTagService = productTagService;
        }

        public override void Execute(object parameter)
        {
            var newProductTagName = _viewModel.TextBoxProductTagEditText.Trim();
            if (newProductTagName != _viewModel.SelectedProductTag.Name)
            {
                var updatedProductTag = new ProductTagModel { Id = _viewModel.SelectedProductTag.Id, Name = newProductTagName };
                var isUpdated = _productTagService.UpdateProductTag(updatedProductTag);
                if (isUpdated)
                {
                    _viewModel.ProductTags.Remove(_viewModel.SelectedProductTag);
                    _viewModel.ProductTags.Add(updatedProductTag);
                }
                else
                {
                    MessageBox.Show("Ошибка при записи в базу данных, попробуйте позже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            _viewModel.MainGridVisibilty = Visibility.Visible;
            _viewModel.GridEditProdutTagVisibility = Visibility.Collapsed;
        }
    }
}
