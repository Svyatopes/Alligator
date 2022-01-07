using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SupplyDetailOpen : CommandBase
    {
        private readonly TabItemSuppliesViewModel _viewModel;
        private readonly SupplyDetailService _supplyDetailService;

        public SupplyDetailOpen(TabItemSuppliesViewModel viewModel, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyDetailService = supplyDetailService;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedSupply is not null;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityWindowAllSupplies = Visibility.Collapsed;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Visible;


            var supplyDetailSelected = _supplyDetailService.GetSupplyDetailById(_viewModel.SelectedSupply.Id);
            _viewModel.SupplyDetails = new ObservableCollection<SupplyDetailModel>(supplyDetailSelected);

        }
    }
}
