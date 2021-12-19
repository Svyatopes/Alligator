using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemOrders.xaml
    /// </summary>
    public partial class TabItemOrders : TabItem
    {
       
        private readonly OrderService _orderService;

        public TabItemOrders()
        {
            InitializeComponent();
            _orderService = new OrderService();
            var viewModel = new TabItemOrdersViewModel();
           //ну почему???
            viewModel.Orders = _orderService.GetOrderssWithoutSensitiveData();
            DataContext = viewModel;
        }

        private void ButtonNewOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonDeleteOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
