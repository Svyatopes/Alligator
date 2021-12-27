using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class OpenAddOrderWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;

        public OpenAddOrderWindowCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;           
        }

        public override void Execute(object parameter)
        {
            _viewModel.OrdersWindowVisibility = Visibility.Collapsed;
            _viewModel.OrdersInfoWindowVisibility = Visibility.Collapsed;
            _viewModel.AddOrderWindowVisibility = Visibility.Visible;         
        }
    }
}
