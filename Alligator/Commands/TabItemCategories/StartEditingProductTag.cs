using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class StartEditingProductTag : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;

        public StartEditingProductTag(TabItemCategoriesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.MainGridVisibilty = Visibility.Collapsed;
            _viewModel.GridEditProdutTagVisibility = Visibility.Visible;
            _viewModel.TextBoxProductTagEditText = _viewModel.SelectedProductTag.Name;
        }
    }
}
