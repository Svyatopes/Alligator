using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class AddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public AddOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {
            var newAddress = _viewModel.NewAdressText.Trim();
            if (string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Введите адрес");
                _viewModel.NewAdressText=string.Empty;
            }
            else
            _orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress);
            _viewModel.AllOrders.Add(_orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress));

        }
    }
}
