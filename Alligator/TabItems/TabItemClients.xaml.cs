using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemClients.xaml
    /// </summary>
    public partial class TabItemClients : TabItem
    {
        TabItemClientsViewModel clientsViewModel = new TabItemClientsViewModel();
        public TabItemClients()
        {
            InitializeComponent();
            DataContext = clientsViewModel;
        }
    }
}
