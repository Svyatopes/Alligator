using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            ViewModel = new TabItemSuppliesViewModel();
            DataContext = ViewModel;

            InitialFillViewModel();
        }

        private void InitialFillViewModel()
        {
            ViewModel.Supplies.Add(new SuppliesViewModel() { Id = 125, Date = new DateTime(2021, 05, 08), Details = ViewModel.SupplyDetails });
            ViewModel.Product.Add(new ProductViewModel() { Name = "Роза" });
            ViewModel.SupplyDetails.Add(new SupplyDelailsViewModel() { Product = ViewModel.Product.Last(), Amount = 15 });
            ViewModel.Product.Add(new ProductViewModel() { Name = "Ромашка" });

            ViewModel.SupplyDetails.Add(new SupplyDelailsViewModel() { Product = ViewModel.Product.Last(), Amount = 10 });

        }

        private void ButtonDeleteClient_AllClients_Click(object sender, RoutedEventArgs e)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить поставку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                ViewModel.Supplies.Remove(ViewModel.Selected);
        }

        private void ButtonAddNewSupply_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.TextBoxNewIdText = 0;
            ViewModel.TextBoxNewProductText = "";
            ViewModel.TextBoxNewAmountText = 0;

            ViewModel.Supply = new SuppliesViewModel();
            ViewModel.SupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            ViewModel.Product = new ObservableCollection<ProductViewModel>();
            SupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;

        }

        private void ButtonOpenClientCard_AllClients_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AddSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
            ViewModel.Supply = ViewModel.Selected;
            ViewModel.SupplyDetails = ViewModel.Supply.Details;
        
        }

        private void ButtonReturnBack_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }

        private void ButtonSavedAll_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Supply = new SuppliesViewModel()
            {
                Id = ViewModel.TextBoxNewIdText,
                Date = DatePickerBooox.SelectedDate.Value,
                Details = ViewModel.SupplyDetails
            };

            ViewModel.Supplies.Add(ViewModel.Supply);

        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Product.Add(new ProductViewModel()
            {
                Id = ViewModel.TextBoxNewIdText,
                Name = ViewModel.TextBoxNewProductText

            });

            ViewModel.SupplyDetails.Add(new SupplyDelailsViewModel()
            {
                Product = ViewModel.Product[0],
                Amount = ViewModel.TextBoxNewAmountText
            });
            ViewModel.Product = new ObservableCollection<ProductViewModel>();

        }

        private void ButtonReturnBackk_Click(object sender, RoutedEventArgs e)
        {
            AddSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }
    }
}
