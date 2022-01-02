using Alligator.BusinessLayer.Models;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SupplyAdd : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;


        public SupplyAdd(TabItemSuppliesViewModel viewModel) 
        {
            _viewModel = viewModel;            
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityWindowAllSupplies = Visibility.Collapsed;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Visible;            
            
        }
    }
}

