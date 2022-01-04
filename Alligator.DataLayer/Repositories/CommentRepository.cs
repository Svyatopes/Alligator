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
    public class CommentRepository
    {
        private const string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        
        public Comment GetCommentById(int id)
        {
            string proc = "dbo.Comment_SelectById";
            using SqlConnection conn = new SqlConnection(_connection);
            return conn.Query<Comment, Client, Comment>(proc,
                (comment, client) =>
                {
                    comment.Client = client;
                    return comment;
                },
             new { Id = id },
             commandType: CommandType.StoredProcedure,
             splitOn: "Id")
             .FirstOrDefault();
        }

        public List<Comment> GetAllCommentsByCLientId(int clientId)
        {
            using var connection = new SqlConnection(_connection);
            string proc = "dbo.Comment_SelectByClientId";
            var comments = connection.Query<Comment>(proc, new { ClientId = clientId },
            commandType: CommandType.StoredProcedure)
            .ToList();
            return comments;
        }

        public void InsertCommentById(int clientId, string text)
        {
            string proc = "dbo.Comment_Insert";
            using var connection = new SqlConnection(_connection);
            connection.Execute(proc, new
            { text, clientId },
            commandType: CommandType.StoredProcedure);

        }
        public void DeleteCommentByIdoNE(int id)
        {
            string proc = "dbo.Comment_DeleteByCommentId";
            using var connection = new SqlConnection(_connection);
            connection.Execute(proc, new
            { Id = id },
            commandType: CommandType.StoredProcedure);
        }
        public void DeleteCommentById(int clientId)
        {
            string proc = "dbo.Comment_DeleteByClientId_1";
            using var connection = new SqlConnection(_connection);
            connection.Execute(proc, new
            { ClientId = clientId },
            commandType: CommandType.StoredProcedure);
        }

        public void UpdateCommentById(int id, string text)
        {
            string proc = "dbo.Comment_Update";
            using var connection = new SqlConnection(_connection);
            connection.Execute(proc, new
            {
                Id = id,
                Text = text
            },
            commandType: CommandType.StoredProcedure
            );
        }
    }
}