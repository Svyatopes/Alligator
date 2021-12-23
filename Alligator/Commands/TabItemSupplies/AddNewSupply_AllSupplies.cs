using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class AddNewSupply_AllSupplies : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;



        public AddNewSupply_AllSupplies(TabItemSuppliesViewModel viewModel) : base()
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.TextBoxNewIdText = 0;
            viewModel.TextBoxNewProductText = "";
            viewModel.TextBoxNewAmountText = 0;
            viewModel.TextBoxNewDateText = System.DateTime.Now;
            viewModel.Supply = new SuppliesViewModel();
            viewModel.SupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            viewModel.Product = new ObservableCollection<ProductViewModel>();
            viewModel.VisibilityFirst = Visibility.Collapsed;
            viewModel.VisibilitySecond = Visibility.Visible;
            viewModel.VisibilityThird = Visibility.Collapsed;
            
        }
    }
}

