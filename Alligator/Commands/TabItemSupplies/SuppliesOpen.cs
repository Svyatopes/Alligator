using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SuppliesOpen : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;

        public SuppliesOpen(TabItemSuppliesViewModel viewModel, SupplyService supplyService)
        {
            _viewModel = viewModel;
            _supplyService = supplyService;
        }

        public override void Execute(object parameter)
        {
            //TODO: error when click on add and return
            _viewModel.PSelected.Clear();
            _viewModel.TextBoxNewAmountText = 0;
            _viewModel.TextBoxNewDateText = DateTime.Now;
            _viewModel.VisibilityWindowAllSupplies = Visibility.Visible;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;            
            _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;            

        }

    }
}
