using Alligator.UI.ViewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class DeleteProductTagFromProductToEdit : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;

        public DeleteProductTagFromProductToEdit(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ProductToEdit.ProductTags.Remove(_viewModel.SelectedProductTagToEdit);
        }
    }
}
