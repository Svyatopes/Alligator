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
    public class AddProductWindowOfAddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
        public AddProductWindowOfAddOrderCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var newAmount = _viewModel.NewAmount;
            if (!int.TryParse(newAmount, out _)|| string.IsNullOrEmpty(newAmount))
            {
                MessageBox.Show("Введите количество продуктов");
                return;
            }
            int amount = Convert.ToInt32(newAmount);
            
            if (_viewModel.SelectedProduct is null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            if (_viewModel.NewOrder.OrderDetails is null)
            {
                List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

                _viewModel.NewOrder.OrderDetails = orderDetails;
            }
            if (_viewModel.NewOrderDetails is null)
            {
                _viewModel.NewOrderDetails = new ObservableCollection<OrderDetailModel>();
            }

            var newOrderDetail = new OrderDetailModel() { Product=_viewModel.SelectedProduct, Amount=amount, Order=_viewModel.NewOrder};
            _viewModel.NewOrder.OrderDetails.Add(newOrderDetail);
            _viewModel.NewOrderDetails.Add(newOrderDetail);           
        }
    } 
}

