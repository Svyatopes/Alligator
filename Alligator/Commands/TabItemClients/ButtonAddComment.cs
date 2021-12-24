using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonAddComment : CommandBase
    {

        private TabItemClientsViewModel viewModel;
        public ButtonAddComment(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }



        public override void Execute(object parameter)
        {
            if (viewModel.Selected.Comments is null)
            {
                ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
                viewModel.Selected.Comments = comments;
            }
            viewModel.Selected.Comments.Add(new CommentViewModel()
            {
                Text = viewModel.Comment
            });
            viewModel.Comment = null;
           

        }
    }
}


