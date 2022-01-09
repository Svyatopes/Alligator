using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{

    public class ReturnToMainGrid : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;


        public ReturnToMainGrid(TabItemCategoriesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.MainGridVisibilty = Visibility.Visible;
            _viewModel.GridEditCategoryVisibility = Visibility.Collapsed;
            _viewModel.GridEditProdutTagVisibility = Visibility.Collapsed;
        }
    }
}
