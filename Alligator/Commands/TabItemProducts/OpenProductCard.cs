using Alligator.UI.ViewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class OpenProductCard : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        public OpenProductCard(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.SelectedProductToShow = _viewModel.SelectedProduct.Name;
            _viewModel.VisibilityEditProduct = System.Windows.Visibility.Visible;
            _viewModel.VisibilityAllProducts = System.Windows.Visibility.Collapsed;
        }
    }
}
