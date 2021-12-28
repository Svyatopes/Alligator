
using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
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
        private CommentService _commentService;
        public DeleteComment(TabItemClientsViewModel viewModel, CommentService commentService)
        {
            _viewModel = viewModel;
            _commentService = commentService;
        }
        public override void Execute(object parameter)
        {

            if (_viewModel.SelectedComment.Client is null)
            {
                var client = new ClientModel() { Id = _viewModel.Selected.Id, FirstName = _viewModel.Selected.FirstName, LastName = _viewModel.Selected.LastName, Patronymic = _viewModel.Selected.Patronymic, Email = _viewModel.Selected.Email, PhoneNumber = _viewModel.Selected.PhoneNumber};
                _viewModel.SelectedComment.Client = client;
            }
            _commentService.DeleteCommentsByClientId(_viewModel.SelectedComment.Client.Id);
            _viewModel.Comments.Remove(_viewModel.SelectedComment);
        }
    }
}
