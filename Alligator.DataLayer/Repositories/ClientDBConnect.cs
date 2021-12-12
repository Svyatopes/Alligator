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
        public List<Client> GetAllClients()
        {
            string proc = "dbo.Client_SelectAll";
            using var conn = new SqlConnection(_connection);
            conn.Open();
            var clients = conn.Query<Client>(proc).ToList();
            return clients;
        }
        public List<Client> GetAllClients1()
        {
            using var connection = new SqlConnection(_connection);
            string proc = "dbo.Client_SelectAll";
            connection.Open();
            var clientDictionary = new Dictionary<int, Client>();
            return connection.Query<Client, Comment, Client>(proc, (client, comment) =>
            {
                client.Comment=comment;

                return client;
            }, commandType: CommandType.StoredProcedure,
              splitOn: "Id")
                .Distinct()
                .ToList();
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
            //1 - удаление из таблицы коментов по clientId = Id
            // delete from table where clientId = Id
            //2 - удаление клиента
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

