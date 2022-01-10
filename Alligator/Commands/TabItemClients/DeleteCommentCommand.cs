
using Alligator.BusinessLayer;
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
    public class DeleteCommentCommand : CommandBase
    {
        private TabItemClientsViewModel _viewModel;
        private CommentService _commentService;

        public DeleteCommentCommand(TabItemClientsViewModel viewModel, CommentService commentService)
        {
            _viewModel = viewModel;
            _commentService = commentService;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedComment is null)
            {
                MessageBox.Show("Выберите комментарий", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _commentService.DeleteCommentByCommentId(_viewModel.SelectedComment.Id);
                _viewModel.Comments.Remove(_viewModel.SelectedComment);
            }
        }
    }
}
