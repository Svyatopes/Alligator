using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{

    public class ReturnCommand : CommandBase
    {
        private TabItemClientsViewModel _viewModel;

        public ReturnCommand(TabItemClientsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AllClients = Visibility.Visible;
            _viewModel.ClientCardVisibility = Visibility.Collapsed;
            _viewModel.AddClient = Visibility.Collapsed;
        }
    }
}
