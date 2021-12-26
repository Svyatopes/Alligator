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
    public class ClientRepository
    {

        string _connection = "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";
        public ClientRepository()
        {

        }

        public List<Client> GetAllClients()
        {
            string proc = "dbo.Client_SelectAll";
            using var conn = new SqlConnection(_connection);
            conn.Open();
            var clients = conn.Query<Client>(proc)
            .ToList();
            return clients;
        }

        public Client GetClientById(int id)
        {
            string proc = "dbo.Client_SelectById";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            return conn.Query<Client, Comment, Client>
            (proc,(client, comment)=>
            {
                if (client.Comments == null)
                {
                    client.Comments = new List<Comment>();
                    client.Comments.Add(comment);
                    return client;
                }
                client.Comments.Add(comment);
                return client;
            },
             new { Id = id },
             commandType: CommandType.StoredProcedure,
             splitOn: "Id")
             .FirstOrDefault();

        }

        public Client GetClientByCommentId(int id)
        {
            string proc = "dbo.Client_SelectByCommentId";
            using SqlConnection conn = new SqlConnection(_connection);
            conn.Open();
            Client client = conn.QueryFirstOrDefault<Client>
            (proc,
            new
            {
                commentId = id 
            },
            commandType: CommandType.StoredProcedure);
            return client;
        }

        public void InsertClient(Client client)
        {
            string proc = "dbo.Insert_Client";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc,new
            { 
                FirstName = client.FirstName,
                LastName = client.LastName,
                Patronymic = client.Patronymic,
                PhoneNumber = client.PhoneNumber, 
                Email = client.Email 
            },
            commandType: CommandType.StoredProcedure
                );
        }

        public void UpdateClient(Client client)
        {
            string proc = "dbo.Client_Update";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc, new 
            {
                client.Id,
                client.FirstName,
                client.LastName,
                client.Patronymic,
                client.PhoneNumber 
            },
            commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteClient(int id)
        {
            string proc1 = "dbo.Client_Delete";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc1, new
            {
                Id =id
            },
            commandType: CommandType.StoredProcedure
            );
        }


    }
}

