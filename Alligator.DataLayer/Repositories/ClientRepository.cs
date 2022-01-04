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
    public class ClientRepository : BaseRepository
    {

        private const string _connection = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
       
        public ClientRepository()
        {

        }

        public List<Client> GetAllClients()
        {
            using IDbConnection connection = GetConnection();            
            var clients = connection.Query<Client>("dbo.Client_SelectAll")
            .ToList();
            return clients;
        }

        public Client GetClientById(int id)
        {
            using IDbConnection connection = GetConnection();
            var clientDictionary = new Dictionary<int, Client>();

            return connection.Query<Client, Comment, Client>
            ("dbo.Client_SelectById",
            (client, comment) =>
            {
                Client clientEntry;

                if (!clientDictionary.TryGetValue(client.Id, out clientEntry))
                {
                    clientEntry = client;
                    clientEntry.Comments = new List<Comment>();
                    clientDictionary.Add(clientEntry.Id, clientEntry);
                }
                if (comment != null)
                    clientEntry.Comments.Add(comment);
                return clientEntry;
            },
             new { Id = id },
             commandType: CommandType.StoredProcedure,
             splitOn: "Id")
             .FirstOrDefault();

        }

        public Client GetClientByCommentId(int id)
        {
            string proc = "dbo.Client_SelectByCommentId";
            using IDbConnection connection = GetConnection();
            Client client = connection.QueryFirstOrDefault<Client>
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
            using IDbConnection connection = GetConnection();
            connection.Execute(proc, new
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
            using IDbConnection connection = GetConnection();
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

        public void DeleteClient(Client client)
        {
            string proc1 = "dbo.Client_Delete";
            using IDbConnection connection = GetConnection();
            connection.Execute(proc1, new
            {
                Id = client.Id
            },
            commandType: CommandType.StoredProcedure
            );
        }


    }
}

