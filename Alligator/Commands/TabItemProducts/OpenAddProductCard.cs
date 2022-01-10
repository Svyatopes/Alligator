using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.ViewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class OpenAddProductCard : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;
        public OpenAddProductCard(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.ProductToAdd = new ProductViewModel();

            _viewModel.VisibilityAddProduct = System.Windows.Visibility.Visible;
            _viewModel.VisibilityAllProducts = System.Windows.Visibility.Collapsed;
        }
    }
}
