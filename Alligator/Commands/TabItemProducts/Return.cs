using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class Return : CommandBase
    {
        private TabItemProductsViewModel _viewModel;
        public Return(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityAddProduct = System.Windows.Visibility.Collapsed;
            _viewModel.VisibilityAllProducts = System.Windows.Visibility.Visible;
            _viewModel.VisibilityProduct = System.Windows.Visibility.Collapsed;
        }
    }
}
