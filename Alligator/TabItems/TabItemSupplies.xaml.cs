using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
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
            ViewModel = new TabItemSuppliesViewModel();
            DataContext = ViewModel;

            InitialFillViewModel();
        }

        private void InitialFillViewModel()
        {
            ViewModel.Supplies.Add(new SuppliesViewModel() { Date = new DateTime(2021, 05, 08) , Amount = 23, Product = "Flowers" });
            ViewModel.Supplies.Add(new SuppliesViewModel() { Date = new DateTime(2018, 02, 16) , Amount = 4, Product = "Sofa"});
            ViewModel.Supplies.Add(new SuppliesViewModel() { Date = new DateTime(2012, 10, 03) , Amount = 67, Product = "Table"});
            ViewModel.Supplies.Add(new SuppliesViewModel() { Date = new DateTime(2010, 12, 24) , Amount = 200, Product = "Candy"});
        }

        private void ButtonSupplyDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var supply = (SuppliesViewModel)button.DataContext;
            var userAnswer = MessageBox.Show("Вы правда хотите удалить заказ?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                ViewModel.Supplies.Remove(supply);
        }

        private void ButtonAddNewSupply_Click(object sender, RoutedEventArgs e)
        {
            var DateToAdd = DatePickerBooox.SelectedDate.Value;
            var AmountToAdd = ViewModel.TextBoxNewAmountText;
            var ProductToAdd = ViewModel.TextBoxNewProductText;                      

            ViewModel.Supplies.Add(new SuppliesViewModel() { Amount = AmountToAdd , Date = DateToAdd, Product = ProductToAdd });           

        }
    }     
}
