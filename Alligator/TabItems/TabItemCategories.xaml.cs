﻿using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemCategories.xaml
    /// </summary>
    public partial class TabItemCategories : TabItem
    {

        private TabItemCategoriesViewModel ViewModel;
        public TabItemCategories()
        {
            InitializeComponent();
            ViewModel = new TabItemCategoriesViewModel();
            DataContext = ViewModel;

        }

    }
}
