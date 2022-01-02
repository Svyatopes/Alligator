using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ChangeCardSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        public ChangeCardSupply(TabItemSuppliesViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityWindowAllSupplies = Visibility.Collapsed;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Visible;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;
            
            _viewModel.TextBoxNewIdText = _viewModel.Selected.Id;
            _viewModel.TextBoxNewDateText = _viewModel.Selected.Date;
            _viewModel.SupplyDetails = _viewModel.Selected.Details;

            var supply = new SupplyModel()
            {
                Id = _viewModel.TextBoxNewIdText,
                Date = _viewModel.TextBoxNewDateText,
                Details = _viewModel.Details
            };
            //TODO
            //_supplyService.UpdateSupply(supply); doesn't work yet

        }
    }
}
