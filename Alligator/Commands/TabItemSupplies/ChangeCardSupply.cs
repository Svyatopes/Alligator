using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ChangeCardSupply : CommandBase
    {
        private TabItemSuppliesViewModel viewModel; 
        public ChangeCardSupply(TabItemSuppliesViewModel viewModel) : base()
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.TextBoxNewIdText = viewModel.Supply.Id;
            //viewModel.TextBoxNewProductText = "";
            //viewModel.TextBoxNewAmountText = 0;
            viewModel.TextBoxNewDateText = viewModel.Supply.Date;
            //viewModel.Supply = new SuppliesViewModel();
            //viewModel.SupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            //viewModel.Product = new ObservableCollection<ProductViewModel>();

            viewModel.VisibilityFirst = Visibility.Collapsed;
            viewModel.VisibilitySecond = Visibility.Visible;
            viewModel.VisibilityThird = Visibility.Collapsed;

            
            viewModel.StateMainDataGrid = false;
            viewModel.Supply = viewModel.Selected;
            viewModel.SupplyDetails = viewModel.Supply.Details;

        }
    }
    
}
