using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ProductAddInSupply : CommandBase
    {
        private readonly TabItemSuppliesViewModel _viewModel;
        private readonly SupplyDetailService _supplyDetailService;

        public ProductAddInSupply(TabItemSuppliesViewModel viewModel, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyDetailService = supplyDetailService;

        }

        public override void Execute(object parameter)
        {
            var nameSelectedProduct = _viewModel.SelectProduct;
            var idSelectedProduct = 0;
            foreach (var item in _viewModel.Products)
            {
                if (item.Name== nameSelectedProduct)
                {
                    idSelectedProduct = item.Id;
                }
            }
            var idProductInDatabase = _supplyDetailService.GetProductById(idSelectedProduct);
                
            var supplyProduct = new SupplyDetailModel()
            {
                Product = idProductInDatabase,
                Amount = _viewModel.TextBoxNewAmountText,
                
            };
            _viewModel.Supply.Details.Add(supplyProduct);
            _viewModel.Supply.Date = _viewModel.NewSupply.Date;
            _viewModel.PSelected = new ObservableCollection<SupplyDetailModel>(_viewModel.Supply.Details);
        }
    }
}
