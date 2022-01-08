using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SaveModifiedSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public SaveModifiedSupply(TabItemSuppliesViewModel viewModel, SupplyService supplyService, SupplyDetailService supplyDetailService)
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
                foreach (var item in _viewModel.Supply.Details)
                {
                    if (item.Id==0)
                    {                        
                        var idSupplyDetailInDatabase = _supplyDetailService.InsertSupplyDetail(item);
                        if (idSupplyDetailInDatabase == -1)
                        {
                            MessageBox.Show("Ошибка при добавлении деталей поставки в БД. Попробуйте позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }                   

                }
                foreach (var item in _viewModel.SelectedDetailForDelete)
                {
                    if (!_supplyDetailService.DeleteSupplyDetailById(item.Id))
                    {
                        MessageBox.Show("Ошибка при удалении. Попробуйте позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                
                _viewModel.Supply = _viewModel.SelectedSupply;
                if (!_supplyService.UpdateSupply(_viewModel.Supply))
                {
                    MessageBox.Show("Ошибка при подключении к БД. Попробуйте позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                _viewModel.Supplies.Clear();
                var supplies = _supplyService.GetAllSupplies();
                foreach (var item in supplies)
                {
                    _viewModel.Supplies.Add(item);
                }

                _viewModel.SupplyDetails = new ObservableCollection<SupplyDetailModel>();
                _viewModel.Supply.Details = new List<SupplyDetailModel>();
                _viewModel.TextBoxNewAmountText = 0;
                _viewModel.TextBoxNewDateText = DateTime.Now;
                _viewModel.VisibilityWindowChangeSupply = Visibility.Collapsed;
                _viewModel.VisibilityWindowAllSupplies = Visibility.Visible;
            }
        }
    }
}



