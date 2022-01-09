﻿using Alligator.BusinessLayer;
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
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            //_viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            //_viewModel.AddOrderWindowVisibility = Visibility.Visible;
            //_viewModel.OrdersWindowVisibility = Visibility.Collapsed;
        }
    }
}
