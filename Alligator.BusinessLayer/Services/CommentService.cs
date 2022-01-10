using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService()
        {
            _commentRepository = new CommentRepository();
        }
        public CommentService(ICommentRepository fakeCommentRepository)
        {
            _commentRepository = fakeCommentRepository;

        }
        public ActionResult<List<CommentModel>> GetAllComments(int id)
        {
            var comments = _commentRepository.GetAllCommentsByCLientId(id);
            try
            {
                return new ActionResult<List<CommentModel>>(true, CustomMapper.GetInstance().Map<List<CommentModel>>(comments));
            }
            catch (Exception exception)
            {
                return new ActionResult<List<CommentModel>>(false, null) { ErrorMessage = exception.Message };
            }
        }

        public int InsertComment(CommentModel comment)
        {
            var comm = CustomMapper.GetInstance().Map<Comment>(comment);
            try
            {
                return _commentRepository.InsertCommentById(comm.Client.Id, comm.Text);
            }
            catch
            {
                return -1;
            }

        }

        public bool DeleteCommentsByClientId(int clientId)
        {
            try
            {
                _commentRepository.DeleteCommentByClientId(clientId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCommentByCommentId(int commentId)
        {
            try
            {
                _commentRepository.DeleteCommentByCommentId(commentId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
