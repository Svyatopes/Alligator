using Alligator.UI.ViewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class OpenProductCard :CommandBase
    {
        private TabItemProductsViewModel _viewModel;
        public OpenProductCard(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.SelectedProductToShow = _viewModel.SelectedProduct.Name;
            _viewModel.VisibilityProduct = System.Windows.Visibility.Visible;
            _viewModel.VisibilityAllProducts = System.Windows.Visibility.Collapsed;
        }
    }
}
