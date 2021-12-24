using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public class DeleteComment : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        public DeleteComment(TabItemClientsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {

            _viewModel.Selected.Comments.Remove(_viewModel.SelectedComment);
        }
    }
}
