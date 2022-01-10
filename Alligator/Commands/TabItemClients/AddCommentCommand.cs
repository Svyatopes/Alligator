using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public class AddCommentCommand : CommandBase
    {

        private TabItemClientsViewModel _viewModel;
        private CommentService _commentService;
        public AddCommentCommand(TabItemClientsViewModel viewModel, CommentService commentService)
        {
            _viewModel = viewModel;
            _commentService = commentService;

        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedClient.Comments is null)
            {
                
               List<CommentModel> coms = new List<CommentModel>();
               
                _viewModel.SelectedClient.Comments = coms;    
            }
            if(_viewModel.Comments is null)
            {
                ObservableCollection<CommentModel> comms = new ObservableCollection<CommentModel>();
                _viewModel.Comments = comms;
            }
          
            
            var newComment = new CommentModel { Client = _viewModel.EditableClient, Text = _viewModel.Comment };
            _viewModel.Comments.Add(newComment);
            
            _commentService.InsertComment(newComment);
            _viewModel.Comment = null;


        }
    }
}


