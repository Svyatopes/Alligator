using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SuppliesOpen : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        
        public SuppliesOpen(TabItemSuppliesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SupplyDetails is not null)
            {
                _viewModel.SupplyDetails.Clear();
                _viewModel.Supply.Details.Clear();
            }
            if (_viewModel.SelectedSupply is not null)
            {
                _viewModel.SelectedSupply = new SupplyModel();
                
            }

            _viewModel.TextBoxNewAmountText = 0;
            _viewModel.TextBoxNewDateText = DateTime.Now;
            _viewModel.VisibilityWindowAllSupplies = Visibility.Visible;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;            
            _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;            

        }

    }
}
