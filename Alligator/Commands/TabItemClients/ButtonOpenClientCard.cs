using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class ButtonOpenClientCard : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        private CommentService _commentService;
        public ButtonOpenClientCard(TabItemClientsViewModel viewModel, CommentService commentService)
        {
            this.viewModel = viewModel;
            _commentService = commentService;

        }
        public override void Execute(object parameter)
        {
            if (viewModel.Selected is null)
            {
                MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (viewModel.Selected.Comments != null)
                {
                    viewModel.Selected.Comments.Clear();
                }
                viewModel.Comments = new ObservableCollection<CommentModel>();
                viewModel.AllClients = Visibility.Collapsed;
                viewModel.ClientCard = Visibility.Visible;

                foreach (var comment in _commentService.GetAllComments(viewModel.Selected.Id))
                    viewModel.Selected.Comments.Add(comment);

                if (viewModel.Selected.Comments != null)
                {
                    viewModel.Comments = new ObservableCollection<CommentModel>(viewModel.Selected.Comments);

                }
                //viewModel.Comments = viewModel.Comments;
            }
        }
    }
}
