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
        string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        public List<Comment> GetCommentsByClientId(int id)
        {
            string proc = "dbo.Comment_SelectByClientId";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            List<Comment> comment = (List<Comment>)conn.Query<Comment>(proc, new { ClientId = id },
            commandType: CommandType.StoredProcedure);
            return comment;
        }
        public List<Comment> GetAllComments()
        {
            string proc = "dbo.Comment_SelectAll";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            var comments = conn.Query<Comment>(proc).ToList();
            return comments;
        }
        public void InsertCommentByClientId(int id, string text)
        {
            string proc = "dbo.Comment_Insert";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { text, id },
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
        public void UpdateCommentById(int id, string text)
        {
            string proc = "dbo.Comment_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { Id=id,Text=text },
                commandType: CommandType.StoredProcedure
                );
        }
        
    }
}