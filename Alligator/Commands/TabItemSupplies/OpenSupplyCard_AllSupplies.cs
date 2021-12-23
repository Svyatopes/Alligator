using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class OpenSupplyCard_AllSupplies : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;

        public OpenSupplyCard_AllSupplies(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.VisibilityFirst = Visibility.Collapsed;
            viewModel.VisibilitySecond = Visibility.Collapsed;
            viewModel.VisibilityThird = Visibility.Visible;
            viewModel.StateMainDataGrid = false;
            viewModel.Supply = viewModel.Selected;
            viewModel.SupplyDetails = viewModel.Supply.Details;
        }

    }
}
