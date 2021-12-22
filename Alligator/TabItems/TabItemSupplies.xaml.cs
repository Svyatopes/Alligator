using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
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
            ViewModel.Supplies.Add(new SuppliesViewModel() { Id = 125, Date = new DateTime(2021, 05, 08) });
            ViewModel.Product.Add(new ProductViewModel() { Name = "Роза" });
            ViewModel.SupplyDetails.Add(new SupplyDelailsViewModel() 
            { 
                Product = ViewModel.Product.Last(), 
                Amount = 15 
            });

            ViewModel.Product.Add(new ProductViewModel() { Name = "Ромашка" });

            ViewModel.SupplyDetails.Add(new SupplyDelailsViewModel() 
            { 
                Product = ViewModel.Product.Last(), 
                Amount = 10 
            });
            ViewModel.Supply = new SupplyViewModel() 
            { 
                Supplies = ViewModel.Supplies, 
                SupplyDetails = ViewModel.SupplyDetails 
            };

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
            //ViewModel.NewProduct.Clear();
            //ViewModel.NewSupply.Clear();

        }

        private void ButtonOpenClientCard_AllClients_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AddSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
            ViewModel.NewSupply = new SupplyViewModel();
            ViewModel.NewSupply.Supplies = new System.Collections.ObjectModel.ObservableCollection<SuppliesViewModel>();
            for (int i = 0; i < ViewModel.Supplies.Count; i++)
            {
                if (ViewModel.Supplies[i].Id == ViewModel.Selected.Id)
                {
                    ViewModel.NewSupply.SupplyDetails = ViewModel.SupplyDetails;
                }
            }
            ViewModel.NewSupply.Supplies.Add( ViewModel.Selected); 
            


        }

        private void ButtonReturnBack_Click(object sender, RoutedEventArgs e)
        {
            SupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }

        private void ButtonSavedAll_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Supplies.Add(ViewModel.NewSupply.Supplies[0]);
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewProduct.Add(new ProductViewModel() 
            { 
                Id = ViewModel.TextBoxNewIdText, 
                Name = ViewModel.TextBoxNewProductText 
            });

            ViewModel.NewSupplyDetails.Add(new SupplyDelailsViewModel() 
            { 
                Product = ViewModel.NewProduct.Last(), 
                Amount = ViewModel.TextBoxNewAmountText 
            });

        }

        private void ButtonAddSSupply_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSupplies.Add(new SuppliesViewModel()
            {
                Id = ViewModel.TextBoxNewIdText,
                Date = DatePickerBooox.SelectedDate.Value
            }
            ); 

            ViewModel.NewSupply = new SupplyViewModel()
            {
                Supplies = ViewModel.NewSupplies,
                SupplyDetails = ViewModel.NewSupplyDetails
            };

        }

        private void ButtonReturnBackk_Click(object sender, RoutedEventArgs e)
        {
            AddSupplyWindow.Width = new GridLength(0, GridUnitType.Star);
            AllSupplyWindow.Width = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }
    }
}
