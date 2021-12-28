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

        string _connection = "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";

        public Comment GetCommentById(int id)
        {
            string proc = "dbo.Comment_SelectById";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
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
            connection.Open();
            var comments = connection.Query<Comment>(proc, new { ClientId = clientId },
            commandType: CommandType.StoredProcedure)
            .ToList();
            return comments;
        }

        public void InsertCommentById(int clientId, string text)
        {
            string proc = "dbo.Comment_Insert";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new
            { text, clientId },
            commandType: CommandType.StoredProcedure);

        }

        public void DeleteCommentById(int clientId)
        {
            string proc = "dbo.Comment_DeleteByClientId_1";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new
            { ClientId = clientId },
            commandType: CommandType.StoredProcedure);
        }

        public void UpdateCommentById(int id, string text)
        {
            string proc = "dbo.Comment_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new
            {
             Id=id,
             Text=text
            },
            commandType: CommandType.StoredProcedure
            );
        }


    }
}