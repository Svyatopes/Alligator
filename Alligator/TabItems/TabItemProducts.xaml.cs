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
        public TabItemProducts()
        {
            InitializeComponent();
            viewModel = new ProductsTabItemViewModel();
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
        }

        
        ProductsTabItemViewModel viewModel = new ProductsTabItemViewModel();

        private void Button_AddProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {           
           
            AllProductsGrid.Width = new GridLength(0, GridUnitType.Star);
            AddProductGrid.Width = new GridLength(1, GridUnitType.Star);
            SeeProductGrid.Width = new GridLength(0, GridUnitType.Star);
        }

        private void Button_SeeProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (viewModel.Selected != null)
            {
                AllProductsGrid.Width = new GridLength(0, GridUnitType.Star);
                AddProductGrid.Width = new GridLength(0, GridUnitType.Star);
                SeeProductGrid.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                MessageBox.Show("Выберите товар", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_DeleteProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Comeback_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AllProductsGrid.Width = new GridLength(1, GridUnitType.Star);
            AddProductGrid.Width = new GridLength(0, GridUnitType.Star);
            SeeProductGrid.Width = new GridLength(0, GridUnitType.Star);
        }

        private void Button_SaveProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
