using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class GetOrdersCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public GetOrdersCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {

            _viewModel.AllOrders = new ObservableCollection<OrderShortModel>(_orderService.GetOrdersWithoutSensitiveData());
                
        }
    }
}
