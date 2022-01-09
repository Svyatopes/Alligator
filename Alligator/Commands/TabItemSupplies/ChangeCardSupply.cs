using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ChangeCardSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        
        public ChangeCardSupply(TabItemSuppliesViewModel viewModel)
        {
            _viewModel = viewModel;         
        }
        

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityWindowAllSupplies = Visibility.Collapsed;
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;
            _viewModel.VisibilityWindowChangeSupply = Visibility.Visible;
            
            _viewModel.TextBoxNewIdText = _viewModel.SelectedSupply.Id;
            _viewModel.TextBoxNewDateText = _viewModel.SelectedSupply.Date;
            

        }
    }
}
