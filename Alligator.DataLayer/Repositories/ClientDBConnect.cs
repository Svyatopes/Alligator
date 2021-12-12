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
        string _connection = "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";
        public Client GetClientById(int id)
        {
            string proc = "dbo.Client_SelectById";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            Client client = conn.QueryFirstOrDefault<Client>(proc, new { Id = id },
            commandType: CommandType.StoredProcedure);
            return client;
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
        // VOZMOZHNO ZAEBIS
        public List<Client> GetAllClients()
        {
            string proc = "dbo.Client_SelectAll";
            using var conn = new SqlConnection(_connection);
            conn.Open();
            var clients = conn.Query<Client>(proc).ToList();
            return clients;
        }

        /// ЗАЕБИСЬ
        public void InsertClient(string fName, string sName, string tName, string phoneNumber, string email)
        {
            string proc = "dbo.Insert_Client";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new { FirstName = fName, LastName = sName, Patronymic = tName, PhoneNumber = phoneNumber, Email = email },
            commandType: CommandType.StoredProcedure
                );
        }
        /// ZAEBIS V ROT EBIS
        public void UpdateClient(Client client)
        {
            string proc = "dbo.Client_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new {client.Id, client.FirstName, client.LastName, client.Patronymic, client.PhoneNumber },
            commandType: CommandType.StoredProcedure
                );

        }
        /// TIPA ZAEBIS
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

        //still in process
        //public List<Client> GetAllClientsWithComments()
        //{
        //    string proc = "dbo.Comment_SelectAllWithClients";
        //    using var connection = new SqlConnection(_connection);
        //    connection.Open();
        //    var clientsDictionary = new Dictionary<int, Client>();
        //    return connection
        //        .Query<Client, Comment, Client>(
        //        proc,
        //        (client, comment) =>
        //        {
        //            Client clientEntry;
        //            if (!clientsDictionary.TryGetValue(client.Id, out clientEntry))
        //            {
        //                clientEntry = client;
        //                clientEntry.Comments = new List<Comment>();
        //                clientsDictionary.Add(clientEntry.Id, clientEntry);
        //            }
        //            if (comment != null)
        //                clientEntry.Comments.Add(comment);
        //            return clientEntry;
        //        },
        //        commandType: CommandType.StoredProcedure,
        //        splitOn: "Id"
        //        )
        //        .Distinct()
        //        .ToList();
        //}
    }
}

