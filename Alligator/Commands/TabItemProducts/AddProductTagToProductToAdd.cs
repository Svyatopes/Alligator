using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class AddProductTagToProductToAdd : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;

        public AddProductTagToProductToAdd(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedProductTagToAdd is null)
            {
                MessageBox.Show("Вы должны выбрать тэг перед тем как добавлять");
                return;
            }

            if (_viewModel.ProductToAdd.ProductTags.Contains(_viewModel.SelectedProductTagToAdd))
            {
                MessageBox.Show("Этот тег уже добавлен");
                return;
            }

            _viewModel.ProductToAdd.ProductTags.Add(_viewModel.SelectedProductTagToAdd);
        }
    }
}
