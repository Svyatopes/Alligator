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
            ViewModel.VisibilitySecond = Visibility.Collapsed;
            ViewModel.VisibilityThird = Visibility.Collapsed;

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

        
    }
}
