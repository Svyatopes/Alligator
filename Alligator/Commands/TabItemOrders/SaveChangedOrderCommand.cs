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
    class SaveChangedOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;

        public SaveChangedOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
        }

        public override void Execute(object parameter)
        {
            var address = _viewModel.ChangedAddressText;
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Введите адрес");
                _viewModel.NewAddressText = string.Empty;
            }
            address = _viewModel.ChangedAddressText.Trim();

            if (_viewModel.SelectedClient is null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            if (_viewModel.SelectedOrder.OrderDetails.Count==0)
            {
                MessageBox.Show("Выберите продукты и их количество");
                return;
            }
            _orderService.EditOrderModel(_viewModel.ChangedDate, _viewModel.SelectedOrder.Id, _viewModel.SelectedClient.Id, address);
            _viewModel.SelectedOrder.Address = address;
            _viewModel.SelectedOrder.Date = _viewModel.ChangedDate;
            _viewModel.SelectedOrder.Client = _viewModel.SelectedClient;
            //добавить сообщение, что всё успешно сохранено
            //и проверку на связь с БД
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Visible;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
        }
    }
}
