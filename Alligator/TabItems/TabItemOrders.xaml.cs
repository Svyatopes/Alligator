using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemOrders.xaml
    /// </summary>
    public partial class TabItemOrders : TabItem
    {
        private TabItemOrdersViewModel _viewModel;
        public TabItemOrders()
        {
            InitializeComponent();
            _viewModel = new TabItemOrdersViewModel();
            DataContext = _viewModel;
            _viewModel.VisibilityThird = Visibility.Collapsed;
            _viewModel.VisibilitySecond = Visibility.Collapsed;
        }

        private void ButtonNewOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }

        private void ButtonDeleteOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

       

        private void ButtonComeBack_OrderWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //OrderWindow.Width = new GridLength(0, GridUnitType.Star);
            //AllOrdersWindow.Width = new GridLength(1, GridUnitType.Star);
        }

        private void ButtonDeleteOrder_OrderWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonSaveChanges_OrderWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonAddNewOrder_AllOrders_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //AllOrdersWindow.Width = new GridLength(0, GridUnitType.Star);
            //AddOrderWindow.Width = new GridLength(1, GridUnitType.Star);
        }

        private void ButtonDeleteOrder_AllOrders_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonComeBack_AddingOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        //    AllOrdersWindow.Width = new GridLength(1, GridUnitType.Star);
        //    AddOrderWindow.Width = new GridLength(0, GridUnitType.Star);
        }

        private void ButtonSaveChanges_AddingOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonOpenOrderWindow_AllOrders_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //OrderWindow.Width = new GridLength(1, GridUnitType.Star);
            //AllOrdersWindow.Width = new GridLength(0, GridUnitType.Star);
        }

      


        private void Button_AddReview_Order_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddReview_OrderWindow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
