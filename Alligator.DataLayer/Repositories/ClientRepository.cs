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

        string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

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
            Client client = conn.QueryFirstOrDefault<Client>
            (proc, new
            { 
                Id = id 
            },
            commandType: CommandType.StoredProcedure);
            return client;

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
            string proc1 = "dbo.Comment_DeleteByClientId";
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

