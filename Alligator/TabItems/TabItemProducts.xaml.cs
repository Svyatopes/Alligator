
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemProducts.xaml
    /// </summary>
    public partial class TabItemProducts : TabItem
    {
        TabItemProductsViewModel _viewModel = new TabItemProductsViewModel();

        public TabItemProducts()
        {
            InitializeComponent();
            _viewModel = new TabItemProductsViewModel();
            DataContext = _viewModel;
            _viewModel.VisibilityAddProduct = Visibility.Collapsed;
            _viewModel.VisibilityProduct = Visibility.Collapsed;
        }      
        

      
    }
}
