using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ReturnBack_CardSupply : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;

        public ReturnBack_CardSupply(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.VisibilityFirst = Visibility.Visible;
            viewModel.VisibilitySecond = Visibility.Collapsed;
            viewModel.VisibilityThird = Visibility.Collapsed;

        }

    }
}
