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
            viewModel = new TabItemProductsViewModel();
            DataContext = viewModel;
            
            ObservableCollection<ProductViewModel> productsList = new ObservableCollection<ProductViewModel>();
            productsList.Add(new ProductViewModel()
            {
                Name = "pr1",
                Category = "cat1"
            }
            );
            dg_Products.ItemsSource = productsList;
            viewModel.Selected = null;

            viewModel.ViewProductGrid = Visibility.Collapsed;
            viewModel.AddProductGrid = Visibility.Collapsed;
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
