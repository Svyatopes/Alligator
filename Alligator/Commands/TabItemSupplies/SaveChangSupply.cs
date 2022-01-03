using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SaveChangSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public SaveChangSupply(TabItemSuppliesViewModel viewModel, SupplyService supplyService, SupplyDetailService supplyDetailService)
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

            var userAnswer = MessageBox.Show("Данные введены верно? Изменить текущую поставку?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (userAnswer == MessageBoxResult.Yes)
            {

                var idSupplyInDatabase = _viewModel.SupplyDetails[0].SupplyId;
                foreach (var item in _viewModel.Supply.Details)
                {
                    item.SupplyId = idSupplyInDatabase;
                    _supplyDetailService.InsertSupplyDetail(item);

                }
                _viewModel.Supply = _supplyService.GetSupplyById(idSupplyInDatabase);
                _viewModel.Supply.Date = _viewModel.Selected.Date;


                _supplyService.UpdateSupply(_viewModel.Supply);

                _viewModel.Supplies.Clear();
                var supplies = _supplyService.GetAllSupplies();
                foreach (var item in supplies)
                {
                    _viewModel.Supplies.Add(item);
                }
                _viewModel.PSelected = new List<SupplyDetailModel>();
                _viewModel.SupplyDetails = new List<SupplyDetailModel>();
                _viewModel.Supply.Details = new List<SupplyDetailModel>();
                _viewModel.TextBoxNewAmountText = 0;
                _viewModel.TextBoxNewDateText = DateTime.Now;
                _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;
                _viewModel.VisibilityWindowAllSupplies = Visibility.Visible;




            }
        }
    }
}



