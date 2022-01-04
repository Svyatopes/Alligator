using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SaveNewSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public SaveNewSupply(TabItemSuppliesViewModel viewModel, SupplyService supplyService, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyService = supplyService;
            _supplyDetailService = supplyDetailService;
        }

        public override void Execute(object parameter)
        {

            if (_viewModel.Supplies == null)
            {
                _viewModel.Supplies = new ObservableCollection<SupplyModel>();                
            }
            
            var userAnswer = MessageBox.Show("Данные введены верно? Сохранить поставку?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (userAnswer == MessageBoxResult.Yes)
            {
                _viewModel.Supply.Date = _viewModel.NewSupply.Date;

                var idSupplyInDatabase = _supplyService.InsertSupply(_viewModel.Supply);
                foreach (var item in _viewModel.Supply.Details)
                {
                    item.SupplyId = idSupplyInDatabase;
                    _supplyDetailService.InsertSupplyDetail(item);
                    
                }                 
                
                _supplyService.UpdateSupply(_viewModel.Supply);

                _viewModel.Supplies.Clear();
                var supplies = _supplyService.GetAllSupplies();
                foreach (var item in supplies)
                {
                    _viewModel.Supplies.Add(item);
                }
                _viewModel.PSelected = new ObservableCollection<SupplyDetailModel>();
                _viewModel.SupplyDetails = new ObservableCollection<SupplyDetailModel>();
                _viewModel.Supply.Details = new List<SupplyDetailModel>();

                _viewModel.TextBoxNewAmountText = 0;
                _viewModel.TextBoxNewDateText = DateTime.Now;
                _viewModel.VisibilityWindowAddNewSupply = Visibility.Collapsed;
                _viewModel.VisibilityWindowAllSupplies = Visibility.Visible;


               

            }
        }
    }
}


