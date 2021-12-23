using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class AddProductInSupply : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;


        public AddProductInSupply(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.Product.Add(new ProductViewModel()
            {
                Id = viewModel.TextBoxNewIdText,
                Name = viewModel.TextBoxNewProductText

            });

            viewModel.SupplyDetails.Add(new SupplyDelailsViewModel()
            {
                Product = viewModel.Product[0],
                Amount = viewModel.TextBoxNewAmountText
            });
            viewModel.Product = new ObservableCollection<ProductViewModel>();
        }
    }
}
