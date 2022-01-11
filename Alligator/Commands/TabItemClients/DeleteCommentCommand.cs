using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class DeleteCommentCommand : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly CommentService _commentService;

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
