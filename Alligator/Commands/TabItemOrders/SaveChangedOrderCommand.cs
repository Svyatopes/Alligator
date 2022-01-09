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

            if (_viewModel.SelectedChangeClient is null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }

            if (_viewModel.SelectedOrder.OrderDetails.Count == 0)
            {
                MessageBox.Show("Выберите продукты и их количество");
                return;
            }
            _viewModel.SelectedOrder.Address = address;
            _viewModel.SelectedOrder.Date = _viewModel.ChangedDate;
            _viewModel.SelectedOrder.Client = _viewModel.SelectedClient;
            _orderService.EditOrderModel(_viewModel.ChangedDate, _viewModel.SelectedOrder.Id, _viewModel.SelectedChangeClient.Id, address);
            var order = _orderService.GetOrderByIdWithDetailsAndReviews(_viewModel.SelectedOrder.Id);
            _viewModel.OrderReviews = new ObservableCollection<OrderReviewModel>(order.OrderReviews);
            _viewModel.OrderDetails = new ObservableCollection<OrderDetailModel>(order.OrderDetails);
            _viewModel.SelectedOrderDate = _viewModel.SelectedOrder.Date;
            _viewModel.SelectedOrderAddress = _viewModel.SelectedOrder.Address;
            _viewModel.SelectedOrderClient = _viewModel.SelectedOrder.Client;
            //добавить сообщение, что всё успешно сохранено
            //и проверку на связь с БД
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Visible;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
        }
    }
}
