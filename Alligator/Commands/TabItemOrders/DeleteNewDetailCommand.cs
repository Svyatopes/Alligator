﻿using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class DeleteNewDetailCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;

        public DeleteNewDetailCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedNewOrderDetail is not null;
        }
        public override void Execute(object parameter)
        {
            _viewModel.NewOrderDetails.Remove(_viewModel.SelectedNewOrderDetail);
        }
    }
}