using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class AddOrderCommand : CommandBase
    {
        private readonly TabItemOrdersViewModel _viewModel;
        private readonly OrderService _orderService;
        private readonly OrderReviewService _orderReviewService;
        private readonly OrderDetailService _orderDetailService;

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
            if (_viewModel.NewOrder.OrderDetails.Count == 0)
            {
                MessageBox.Show("Выберите продукты и их количество");
                return;
            }
            int orderId = _orderService.AddOrderModel(_viewModel.NewDate, _viewModel.SelectedClient.Id, newAddress);
            if (orderId != -1)
            {
                _orderReviewService.AddOrderReviewModels(_viewModel.NewOrderReviews, orderId);
                _orderDetailService.AddOrderDetailModels(_viewModel.NewOrderDetails, orderId);
                _viewModel.AllOrders.Add(_orderService.GetOrderByIdWithDetailsAndReviews(orderId).Data);
                MessageBox.Show("Заказ создан");
                _viewModel.NewAmount = string.Empty;
                _viewModel.ComeBackFirstWindow.Execute(null);
            }
        }
    }
}
