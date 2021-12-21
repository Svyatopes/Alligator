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
            dg_Products.ItemsSource = viewModel.Products;

            ObservableCollection<ProductViewModel> productsList = new ObservableCollection<ProductViewModel>();
            productsList.Add(new ProductViewModel()
            {
                Name = "pr1",
                Category = "cat1"
            }
            );

        }

        
        ProductsTabItemViewModel viewModel = new ProductsTabItemViewModel();

        private void Button_AddProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (viewModel.Selected == null)
            {
                AllProductsGrid.Width = new GridLength(0, GridUnitType.Star);
                AddProductGrid.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            viewModel.Selected = null;
        }

        private void Button_SeeProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_DeleteProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
