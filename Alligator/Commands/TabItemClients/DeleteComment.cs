
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
            if (_viewModel.SelectedComment is null)
            {
                MessageBox.Show("Выберите комментарий", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //else if (_viewModel.SelectedComment.Client is null)
            //{
            //    var olist = new ObservableCollection<CommentModel>();
            //    var list = new List<CommentModel>();
            //    olist = _viewModel.Comments;

            //    var client = new ClientModel() { Id = _viewModel.Selected.Id, FirstName = _viewModel.Selected.FirstName, LastName = _viewModel.Selected.LastName, Patronymic = _viewModel.Selected.Patronymic, Email = _viewModel.Selected.Email, PhoneNumber = _viewModel.Selected.PhoneNumber, Comments = list };
            //    list = client.Comments;
            //    foreach(var item in olist)
            //    {
            //        list.Add(item);
            //    }
            //    client.Comments = list;
            //    _viewModel.SelectedComment.Client = client;
            //    if(_viewModel.SelectedComment.Client is not null)
            //    {
            //        _commentService.DeleteCommentByCommentId(_viewModel.SelectedComment.Id);
            //        _viewModel.Comments.Remove(_viewModel.SelectedComment);
            //    }
            //}
            else
            {
                _commentService.DeleteCommentByCommentId(_viewModel.SelectedComment.Id);
                _viewModel.Comments.Remove(_viewModel.SelectedComment);
            }
        }
    }
}
