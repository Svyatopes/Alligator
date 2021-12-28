using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemClients.xaml
    /// </summary>
    public partial class TabItemClients : TabItem
    {
        TabItemClientsViewModel viewModel = new TabItemClientsViewModel();    
        public TabItemClients()
        {
            InitializeComponent();
            viewModel = new TabItemClientsViewModel();
            DataContext = viewModel;
           
            viewModel.AddClient = Visibility.Collapsed;
            viewModel.ClientCard = Visibility.Collapsed;

            
        }







    }
}
