using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
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
        TabItemProductsViewModel viewModel = new TabItemProductsViewModel();

        public TabItemProducts()
        {
            InitializeComponent();
            _viewModel = new TabItemProductsViewModel();
            DataContext = _viewModel;
            _viewModel.VisibilityAddProduct = Visibility.Collapsed;
            _viewModel.VisibilityProduct = Visibility.Collapsed;
        }      
        

        private void AddProduct(object sender, System.Windows.RoutedEventArgs e)
        {           
           
            
        }

        private void ViewProduct(object sender, System.Windows.RoutedEventArgs e)
        {
            if (viewModel.Selected != null)
            {
                AllProductsGrid.Width = new GridLength(0, GridUnitType.Star);
                AddProductGrid.Width = new GridLength(0, GridUnitType.Star);
                ViewProductGrid.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                MessageBox.Show("Выберите товар", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DeleteProduct(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Comeback(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void SaveProduct(object sender, System.Windows.RoutedEventArgs e)
        {
            //TODO do it later
        }
    }
}
