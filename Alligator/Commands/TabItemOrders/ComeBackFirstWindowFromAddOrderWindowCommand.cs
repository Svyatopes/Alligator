using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    class ComeBackFirstWindowFromAddOrderWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;

        public ComeBackFirstWindowFromAddOrderWindowCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Visible;
            _viewModel.NewReviewText = string.Empty;
            _viewModel.NewAmount = string.Empty;
            _viewModel.NewAddressText = string.Empty;
            _viewModel.NewOrderReviews.Clear();
            _viewModel.NewOrderDetails.Clear();
        }
    }
    
    
}
