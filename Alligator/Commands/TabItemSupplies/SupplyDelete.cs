using Alligator.BusinessLayer.Service;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SupplyDelete : CommandBase
    {
        private TabItemSuppliesViewModel _viewModel;
        private SupplyService _supplyService;
        private SupplyDetailService _supplyDetailService;

        public SupplyDelete(TabItemSuppliesViewModel viewModel, SupplyService supplyService, SupplyDetailService supplyDetailService)
        {
            _viewModel = viewModel;
            _supplyService = supplyService;
            _supplyDetailService = supplyDetailService;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedSupply is not null;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить поставку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                if (_supplyDetailService.DeleteSupplyDetailBySupplyId(_viewModel.SelectedSupply.Id)
                    && _supplyService.DeleteSupply(_viewModel.SelectedSupply.Id))
                {
                    _viewModel.Supplies.Remove(_viewModel.SelectedSupply);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении. Попробуйте позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
