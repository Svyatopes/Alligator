using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public TabItemSupplies()
        {
            InitializeComponent();
            _viewModel = new TabItemSuppliesViewModel();
            DataContext = _viewModel;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;
            _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;
            InitialFillViewModel();
        }

        private void InitialFillViewModel()
        {
            _supplyService = new SupplyService();
            _supplyDetailService = new SupplyDetailService();
            _viewModel.Supply = new SupplyModel();
            _viewModel.Products = new List<ProductModel>();
            _viewModel.SelectProduct = "";
            _viewModel.Supplies = new ObservableCollection<SupplyModel>();
            _viewModel.Supply.Details = new List<SupplyDetailModel>();
            _viewModel.SupplyDetails = new List<SupplyDetailModel>();
            _viewModel.TextBoxNewIdText = 0;
            _viewModel.TextBoxNewAmountText = 0;
            _viewModel.NewSupply = new SupplyModel() { Date = DateTime.Now };
            _viewModel.TextBoxNewDateText = DateTime.Now;
            var supplies = _supplyService.GetAllSupplies();
            var product = _supplyDetailService.GetProduct();
            var suppliesDetail = _supplyDetailService.GetAllSupplyDetails();


            foreach (var item in supplies)
            {
                _viewModel.Supplies.Add(item);
            }
            var ddd = new List<string>();
            foreach (var item in product)
            {
                _viewModel.Products.Add(item);
                ddd.Add(item.Name);
            }
            Product.ItemsSource = ddd;
            Product1.ItemsSource = ddd;


        }
    }
}
