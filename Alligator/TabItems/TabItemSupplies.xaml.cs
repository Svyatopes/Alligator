using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemSupplies.xaml
    /// </summary>
    public partial class TabItemSupplies : TabItem
    {
        public TabItemSuppliesViewModel ViewModel;


        public TabItemSupplies()
        {
            InitializeComponent();
            var product = new ProductViewModel();
            ViewModel = new TabItemSuppliesViewModel();
            DataContext = ViewModel;

            InitialFillViewModel();
        }

        private void InitialFillViewModel()
        {
            List<ProductViewModel> item = new List<ProductViewModel>(); 
            item.Add (new ProductViewModel() { Id = 21, Name = "рюкзак" });
            ViewModel.Products.Add(item.Last());
            item.Add (new ProductViewModel() { Id = 23, Name = "ручка" });
            ViewModel.Products.Add(item.Last());
            ViewModel.Supplies.Add(new SuppliesViewModel() { Id = 231, Date = new DateTime(2021, 05, 08), Amount = 23, Product = ViewModel.Products });
           
        }

        private void ButtonDeleteClient_AllClients_Click(object sender, RoutedEventArgs e)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить поставку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                ViewModel.Supplies.Remove(ViewModel.Selected);
        }

        private void ButtonAddNewSupply_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
            ViewModel.NewProducts.Clear();
            ViewModel.NewSupplies.Clear();



        }


        private void ButtonOpenClientCard_AllClients_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AddSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            
            ViewModel.StateMainDataGrid = false;
            ViewModel.NewProducts=ViewModel.Selected.Product;

        }

        private void ButtonReturnBack_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }

        private void ButtonSavedAll_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Supplies.Add(ViewModel.NewSupplies.Last());
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewProducts.Add(new ProductViewModel() { Id = ViewModel.TextBoxNewAmountText, Name = ViewModel.TextBoxNewProductText });
        }

        private void ButtonAddSSupply_Click(object sender, RoutedEventArgs e)
        {
            var IdToAdd = ViewModel.TextBoxNewIdText;
            var DateToAdd = DatePickerBooox.SelectedDate.Value;
            var AmountToAdd = ViewModel.TextBoxNewAmountText;
            var ProductToAdd = ViewModel.TextBoxNewProductText;
            List<ProductViewModel> item = new List<ProductViewModel>();
            item.Add(new ProductViewModel() { Id = IdToAdd, Name = ProductToAdd });
            ViewModel.NewProducts.Add(new ProductViewModel() { Id = IdToAdd, Name = ProductToAdd });
            ViewModel.NewSupplies.Add(new SuppliesViewModel() { Id = IdToAdd, Amount = AmountToAdd, Date = DateToAdd, Product = ViewModel.NewProducts });
            

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAddNewClient_AllClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReturnBackk_Click(object sender, RoutedEventArgs e)
        {
            AddSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }
    }     
}
