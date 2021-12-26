using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class ComeBackFirstWindowCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;

        public ComeBackFirstWindowCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AddOrderWindow = Visibility.Collapsed;
            _viewModel.OrdersInfoWindow = Visibility.Collapsed;
            _viewModel.AllOrdersWindow = Visibility.Visible;           
        }
    }
}
