using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class ProductDeleteFromSupply : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;


        public ProductDeleteFromSupply(TabItemSuppliesViewModel viewModel)
        {
            _viewModel = viewModel;            
        }

        public override void Execute(object parameter)
        {
            
            var userAnswer = MessageBox.Show("Вы правда хотите удалить продукт?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes) { }
            
            _viewModel.SelectedDetailForDelete.Add(_viewModel.SelectedDetail);
            _viewModel.SelectedDetails.Remove(_viewModel.SelectedDetail);
            _viewModel.Supply.Details = new System.Collections.Generic.List<BusinessLayer.Models.SupplyDetailModel>(_viewModel.SelectedDetails);
            
        }
    }
}

