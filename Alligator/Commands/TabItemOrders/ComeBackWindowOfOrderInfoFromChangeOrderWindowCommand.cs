using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    class ComeBackWindowOfOrderInfoFromChangeOrderWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;

        public ComeBackWindowOfOrderInfoFromChangeOrderWindowCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Visible;
            _viewModel.ChangeOrderWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
        }    
    }
}
