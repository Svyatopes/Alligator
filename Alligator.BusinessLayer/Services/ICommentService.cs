using Alligator.BusinessLayer.Models;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Services
{
    public interface ICommentService
    {
        void DeleteCommentByCommentId(int commentId);
        bool DeleteCommentsByClientId(int clientId);
        ActionResult<List<CommentModel>> GetAllComments(int id);
        int InsertComment(CommentModel comment);
    }
}