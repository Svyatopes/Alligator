using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class ComeBackFirstWindowCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderService _orderService;

        public ComeBackFirstWindowCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Visible;
            _viewModel.AllOrders.Clear();
            if (_orderService.GetOrders().Success is true)
            {
                var orders = _orderService.GetOrders().Data;
                foreach (var order in orders)
                    _viewModel.AllOrders.Add(order);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }
        }
    }
}
