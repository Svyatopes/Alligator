using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ProductDeleteFromSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyDetailService _supplyDetailService;


        public ProductDeleteFromSupply(TabItemSuppliesViewModel viewModel, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyDetailService = supplyDetailService;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить продукт?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes) { }
                //_supplyDetailService.DeleteSupplyDetail(_viewModel.PrSelected.Id);
                //todo
        }
    }
}

