using Alligator.DataLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Repositories
{
    public class CommentDBConnect
    {
        string _connection = "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";
        public List<Comment> GetCommentsByClientId(Client client)
        {
            string proc = "dbo.Client_SelectClientByCommentId";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            List<Comment> comment = (List<Comment>)conn.Query<Comment>(proc, new { client.Id },
            commandType: CommandType.StoredProcedure);
            return comment;
        }
        public void InsertCommentByClientId(Client client, string text)
        {
            string proc = "dbo.Comment_Insert";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            int Id = client.Id;
            connection.Execute(proc, new { text, Id },
            commandType: CommandType.StoredProcedure
               );

        }
        public void DeleteCommentById(int id)
        {
            string proc = "dbo.Comment_Delete";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { Id = id },
                 commandType: CommandType.StoredProcedure
                );
        }
        public void UpdateComment(Comment comment)
        {
            string proc = "dbo.Comment_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { comment.Id, comment.Text },
                commandType: CommandType.StoredProcedure
                );
        }
        //public List<Comment> GetAllComments()
        //{
        //    string proc = "dbo.Comment_SelectAll";
        //    using SqlConnection conn = new SqlConnection(_connection);
        //    conn.Open();
        //    var result = SqlConnection.Query
        //    List<Comment> comments = conn.Query<Comment>(proc).ToList();
        //    return comments;
        //}
    }
}
//getCommentsByClientId
//TODO:getAllComments
//InsertCommentByClientId
//TODO:DeleteCommentByClientId
//TODO:UpdateCommentByClientId