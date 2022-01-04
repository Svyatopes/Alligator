using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class StartEditingCategory : CommandBase
    {
        private readonly TabItemCategoriesViewModel _viewModel;

        public StartEditingCategory(TabItemCategoriesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.MainGridVisibilty = Visibility.Collapsed;
            _viewModel.GridEditProductTagVisibility = Visibility.Visible;
        }

    }
}
