using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

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
        public override bool CanExecute(object parameter)
        {
            return _viewModel.TextBoxNewAmountText !=0 && _viewModel.NameSelectProduct.Name is not null;
        }

        public override void Execute(object parameter)
        {

            var idSelectedProduct = _viewModel.NameSelectProduct.Id;
            
            var ProductInDatabase = _supplyDetailService.GetProductById(idSelectedProduct);
            if (ProductInDatabase.Id==-1)
            {
                MessageBox.Show("Ошибка при подключении к БД. Попробуйте позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ProductInDatabase = new ProductModel();
            }
            _viewModel.Supply.Date = _viewModel.NewSupply.Date;

            var idSupplyInDatabase = 0;
            if (_viewModel.SelectedSupply is not null)
            {
                _viewModel.Supply = _viewModel.SelectedSupply;
                idSupplyInDatabase = _viewModel.Supply.Id;

            }
            var supplyProduct = new SupplyDetailModel()
            {
                Product = ProductInDatabase,
                Amount = _viewModel.TextBoxNewAmountText,
                SupplyId = idSupplyInDatabase,

            };
            if (_viewModel.SupplyDetails is not null)
            {                
                _viewModel.Supply.Details = new List<SupplyDetailModel>();
                foreach (var item in _viewModel.SupplyDetails)
                {
                        _viewModel.Supply.Details.Add(item) ;
                }               
                
            }
            else
            {
                _viewModel.Supply.Details = new List<SupplyDetailModel>();
            }
            _viewModel.Supply.Details.Add(supplyProduct);
            _viewModel.SupplyDetails = new ObservableCollection<SupplyDetailModel>(_viewModel.Supply.Details);

        }
    }
}
