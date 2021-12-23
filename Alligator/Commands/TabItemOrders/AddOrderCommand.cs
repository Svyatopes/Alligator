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

        public string AddAddress(object parameter)
        {
            var NewAddress = _viewModel.NewAdressText.Trim();
            if (string.IsNullOrEmpty(NewAddress))
            {
                MessageBox.Show("Введите адрес");
                return string.Empty;
            }
            return NewAddress;
        }

        public override void Execute(object parameter)
        {
            //_orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, AddAddress);
            //_viewModel.AllOrders.Add(_orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, AddAddress));

        }
    }
}
