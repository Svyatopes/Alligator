using Alligator.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using System.Linq;
using System.Data;
using Alligator.DataLayer.Repositories;

namespace Alligator.DataLayer.Repositories
{
    public class ClientDBConnect
    {
        string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        public Client GetClientById(int id)
        {
            string proc = "dbo.Client_SelectById";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            Client client = conn.QueryFirstOrDefault<Client>(proc, new { Id = id },
            commandType: CommandType.StoredProcedure);
            return client;
        }
        public List<Client> GetAllClients1()
        {
            using var conn = new SqlConnection(_connection);
            conn.Open();
            var result = conn.Query<Client, Comment, Client>
                ("dbo.Client_SelectAll",(client, comment) =>
                {
                    client.Comment=comment;
                    if(client.Comments==null)
                    {
                        client.Comments = new List<Comment>();
                    }
                    client.Comments.Add(comment);
                    return client;
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();
            return result;
        }
        public Client GetClientByCommentId(int id)
        {
            string proc = "dbo.Client_SelectByCommentId";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            Client client = conn.QueryFirstOrDefault<Client>(proc, new { commentId = id },
            commandType: CommandType.StoredProcedure);
            return client;
        }
        public List<Client> GetAllClients()
        {
            string proc = "dbo.Client_SelectAll";
            using var conn = new SqlConnection(_connection);
            conn.Open();
            var clients = conn.Query<Client>(proc).ToList();
            return clients;
        }
        public void InsertClient(string fName, string sName, string tName, string phoneNumber, string email)
        {
            string proc = "dbo.Insert_Client";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { FirstName = fName, LastName = sName, Patronymic = tName, PhoneNumber = phoneNumber, Email = email },
            commandType: CommandType.StoredProcedure
                );
        }
        public void UpdateClient(Client client)
        {
            string proc = "dbo.Client_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new {client.Id, client.FirstName, client.LastName, client.Patronymic, client.PhoneNumber },
            commandType: CommandType.StoredProcedure
                );

        }
        public void DeleteClient(int id)
        {
            string proc = "dbo.Client_Delete";
            string proc1 = "dbo.Comment_DeleteByClientId";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc1, new { Id =id },
            commandType: CommandType.StoredProcedure);
            connection.Execute(proc, new { Id =id},
            commandType: CommandType.StoredProcedure
                );
        }
        public List<Client> GetAllClientsWithComments()
        {
            using var connection = new SqlConnection(_connection);
            string proc = "dbo.Client_SelectAll";
            connection.Open();
            var clientDictionary = new Dictionary<int, Client>();
            return connection.Query<Client, Comment, Client>(proc, (client, comment) =>
            {
                client.Comment = comment;

                return client;
            }, commandType: CommandType.StoredProcedure,
              splitOn: "Id")
                .Distinct()
                .ToList();
        }
    }
}

