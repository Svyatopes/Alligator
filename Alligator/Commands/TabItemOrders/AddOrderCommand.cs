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
    public class AddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        private OrderService _orderService;
        private OrderReviewService _orderReviewService;
        private OrderDetailService _orderDetailService;

        public AddOrderCommand(TabItemOrdersViewModel viewModel, OrderService orderService, OrderReviewService orderReviewService
        , OrderDetailService orderDetailService)
        {
            _viewModel = viewModel;
            _orderService = orderService;
            _orderReviewService = orderReviewService;
            _orderDetailService = orderDetailService;
        }

        public override void Execute(object parameter)
        {            
            var newAddress = _viewModel.NewAddressText;
            if (string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Введите адрес");
                _viewModel.NewAddressText = string.Empty;
            }
            newAddress = _viewModel.NewAddressText.Trim();
            
            if (_viewModel.SelectedClient is null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            
            if (_viewModel.NewOrder.OrderDetails is null)
            {                
                _viewModel.NewOrder.OrderDetails = new List<OrderDetailModel>();
            }
            if (_viewModel.NewOrderDetails is null)
            {
                _viewModel.NewOrderDetails = new ObservableCollection<OrderDetailModel>();
            }
            if (_viewModel.NewOrder.OrderDetails.Count==0)
            {
                MessageBox.Show("Выберите продукты и их количество");
                return;
            }

           int orderId = _orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress);             
           if (orderId == -1)
           {
                 MessageBox.Show("Ошибка при добавлении заказа в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
           }                     
               _orderReviewService.AddOrderReviewModels(_viewModel.NewOrderReviews);        
               _orderDetailService.AddOrderDetailModels(_viewModel.NewOrderDetails);
           
           if (_orderService.GetOrderByIdWithDetailsAndReviews(orderId).Success)
           {
                var ordersWithDetailsAndReviews = _orderService.GetOrderByIdWithDetailsAndReviews(orderId).Data;
                _viewModel.AllOrders.Add(ordersWithDetailsAndReviews);
                MessageBox.Show("Заказ добавлен");
                _viewModel.NewReviewText = string.Empty;
                _viewModel.NewAmount = string.Empty;
                _viewModel.NewAddressText = string.Empty;
                _viewModel.NewOrderReviews.Clear();
                _viewModel.NewOrderDetails.Clear();
                _viewModel.ComeBackFirstWindow.Execute(null);
            }
            else
            {
                MessageBox.Show("Ошибка", "Error", MessageBoxButton.OK);
            }
        }
    }
}

