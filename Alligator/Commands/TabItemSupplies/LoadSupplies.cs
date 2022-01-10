using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.DataLayer.Entities;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class LoadSupplies : CommandBase
    {
        private readonly TabItemSuppliesViewModel _viewModel;
        private readonly SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public LoadSupplies(TabItemSuppliesViewModel viewModel, SupplyService supplyService, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyService = supplyService;
            _supplyDetailService = supplyDetailService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
            _viewModel.VisibilityWindowOpenSupplyDetailCard = Visibility.Collapsed;
            _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;

            

            _viewModel.Supply = new SupplyModel();
            _viewModel.Products = new ObservableCollection<ProductModel>();
            _viewModel.NameSelectProduct = new ProductModel();
            _viewModel.Supplies = new ObservableCollection<SupplyModel>();            
            _viewModel.Supply.Details = new List<SupplyDetailModel>();
            _viewModel.SelectedDetailForDelete = new List<SupplyDetailModel>();
            _viewModel.TextBoxNewIdText = 0;
            _viewModel.TextBoxNewAmountText = 0;
            _viewModel.NewSupply = new SupplyModel() { Date = DateTime.Now };
            _viewModel.TextBoxNewDateText = DateTime.Now;
            var supplies = _supplyService.GetAllSupplies();
            var product = _supplyDetailService.GetProducts();
            

            foreach (var item in supplies)
            {
                _viewModel.Supplies.Add(item);
            }
            
            foreach (var item in product)
            {
                _viewModel.Products.Add(item);
            }
        }

    }
}
