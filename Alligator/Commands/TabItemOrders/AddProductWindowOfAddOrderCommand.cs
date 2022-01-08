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
    class AddProductWindowOfAddOrderCommand : CommandBase
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
            if (_viewModel.OrderDetails is null)
            {
                ObservableCollection<OrderDetailModel> orderDetails = new ObservableCollection<OrderDetailModel>();

                _viewModel.NewOrderDetails = orderDetails;
            }

            var newOrderDetail = new OrderDetailModel() { Product=_viewModel.SelectedProduct, Amount=amount};
            _viewModel.NewOrderDetails.Add(newOrderDetail);           
        }
    } 
}

