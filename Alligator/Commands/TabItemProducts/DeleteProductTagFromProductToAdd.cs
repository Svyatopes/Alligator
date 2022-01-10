using Alligator.UI.ViewModels.TabItemsViewModels;

namespace Alligator.UI.Commands.TabItemProducts
{
    public class DeleteProductTagFromProductToAdd : CommandBase
    {
        private readonly TabItemProductsViewModel _viewModel;

        public DeleteProductTagFromProductToAdd(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ProductToAdd.ProductTags.Remove(_viewModel.SelectedProductTagInProductToAdd);
        }
    }
}
