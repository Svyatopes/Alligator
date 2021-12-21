using Alligator.UI.ViewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemCategories
{
    public class ButtonProductTagDelete : CommandBase
    {
        private TabItemCategoriesViewModel viewModel;

        public ButtonProductTagDelete(TabItemCategoriesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот тэг?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                viewModel.ProductTags.Remove(viewModel.SelectedProductTag);
        }
    }
}
