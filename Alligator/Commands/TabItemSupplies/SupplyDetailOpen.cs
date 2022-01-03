using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SupplyDetailOpen : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyDetailService _supplyDetailService;

        public SupplyDetailOpen(TabItemSuppliesViewModel viewModel, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyDetailService = supplyDetailService;
        }

        public override void Execute(object parameter)
        {
            var supplyDetailSelected = _supplyDetailService.GetSupplyDetailById(_viewModel.Selected.Id);
            
            _viewModel.VisibilityWindowAllSupplies = Visibility.Collapsed;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Visible;

            _viewModel.PSelected = new List<SupplyDetailModel>(supplyDetailSelected);
            
        }
    }
}
