using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{

    public class AddProductTagToProductToEdit : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;

        public AddProductTagToProductToEdit(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedProductTagToAddInProductToEdit is null)
            {
                MessageBox.Show("Вы должны выбрать тэг перед тем как добавлять");
                return;
            }

            if (_viewModel.ProductToEdit.ProductTags.Contains(_viewModel.SelectedProductTagToAddInProductToEdit))
            {
                MessageBox.Show("Этот тег уже добавлен");
                return;
            }

            _viewModel.ProductToEdit.ProductTags.Add(_viewModel.SelectedProductTagToAddInProductToEdit);
        }
    }
}
