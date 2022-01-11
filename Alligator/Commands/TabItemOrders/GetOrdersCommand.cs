using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class GetOrdersCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderService _orderService;

        public GetOrdersCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {

            _viewModel.AllOrders.Clear();
            foreach (var order in _orderService.GetOrders().Data)
            {
                _viewModel.AllOrders.Add(order);
            }

        }
    }
}
