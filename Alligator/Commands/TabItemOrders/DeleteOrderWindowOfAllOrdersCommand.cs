using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class DeleteOrderWindowOfAllOrdersCommand : CommandBase
    {

        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public DeleteOrderWindowOfAllOrdersCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {
            _orderService.DeleteOrderModel(_viewModel.SelectedOrder.Id);
            _viewModel.AllOrders.Remove(_viewModel.SelectedOrder);
        }
    }
}
