using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface ICommentRepository
    {
        void DeleteCommentByClientId(int clientId);
        void DeleteCommentByCommentId(int id);
        List<Comment> GetAllCommentsByCLientId(int clientId);
        Comment GetCommentById(int id);
        int InsertCommentById(int clientId, string text);
        void UpdateCommentById(int id, string text);
    }
}