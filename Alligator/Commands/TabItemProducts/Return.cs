using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class Return : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        public Return(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityAllProducts = Visibility.Visible;
            _viewModel.VisibilityAddProduct = Visibility.Collapsed;
            _viewModel.VisibilityEditProduct = Visibility.Collapsed;
        }
    }
}
