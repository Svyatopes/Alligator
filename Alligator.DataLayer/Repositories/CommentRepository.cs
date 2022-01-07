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
    public class CommentRepository  : BaseRepository
    {
        private const string _connection = /*"Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";*/ "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

        public Comment GetCommentById(int id)
        {
            string proc = "dbo.Comment_SelectById";
            using var conn = GetConnection();
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

            string proc = "dbo.Comment_SelectByClientId";
            using var connection = GetConnection();
            var comments = connection.Query<Comment>(proc, new { ClientId = clientId },
            commandType: CommandType.StoredProcedure)
            .ToList();
            return comments;
        }

        public void InsertCommentById(int clientId, string text)
        {
            string proc = "dbo.Comment_Insert";
            using var connection = GetConnection();
            connection.Execute(proc, new
            { text, clientId },
            commandType: CommandType.StoredProcedure);

        }
        public void DeleteCommentByCommentId(int id)
        {
            string proc = "dbo.Comment_DeleteByCommentId";
            using var connection = GetConnection();
            connection.Execute(proc, new
            { Id= id },
            commandType: CommandType.StoredProcedure);
        }
        public void DeleteCommentByClientId(int clientId)
        {
            string proc = "dbo.Comment_DeleteByClient";
            using var connection = GetConnection();
            connection.Execute(proc, new
            { ClientId = clientId },
            commandType: CommandType.StoredProcedure);
        }

        public void UpdateCommentById(int id, string text)
        {
            string proc = "dbo.Comment_Update";
            using var connection = GetConnection();
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