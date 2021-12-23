using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class GetOrderInfoCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public GetOrderInfoCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {            
            var order = _orderService.GetOrderByIdWithDetailsAndReviews(_viewModel.SelectedOrder.Id);
            _viewModel.OrderReviews = new ObservableCollection<OrderReviewModel> (order.OrderReviews);
            _viewModel.OrderDetails = new ObservableCollection<OrderDetailModel>(order.OrderDetails);
        }
    }
}
