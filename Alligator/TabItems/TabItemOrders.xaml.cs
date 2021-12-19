using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemOrders.xaml
    /// </summary>
    public partial class TabItemOrders : TabItem
    {
        private TabItemOrdersViewModel viewModel;

        public TabItemOrders()
        {
            InitializeComponent();
            viewModel = new TabItemOrdersViewModel();
            DataContext = viewModel;
        }

    }
}
