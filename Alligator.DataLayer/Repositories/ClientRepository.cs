using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {

        private const string _connection =/* "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";*/ "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";


        public List<Client> GetAllClients()
        {
            string proc = "dbo.Client_SelectAll";
            using var conn = GetConnection();
            var clients = conn.Query<Client>(proc)
            .ToList();
            return clients;
        }

        public Client GetClientById(int id)
        {
            string proc = "dbo.Client_SelectById";
            using var conn = BaseRepository.GetConnection();

            var clientDictionary = new Dictionary<int, Client>();

            return conn.Query<Client, Comment, Client>
            (proc,
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
            using var conn = GetConnection();
            Client client = conn.QueryFirstOrDefault<Client>
            (proc,
            new
            {
                commentId = id
            },
            commandType: CommandType.StoredProcedure);
            return client;
        }

        public int InsertClient(Client client)
        {
            string proc = "dbo.Client_Insert";
            using var connection = GetConnection();
            return connection.QueryFirstOrDefault<int>(proc, new
            {
                client.FirstName,
                client.LastName,
                client.Patronymic,
                client.PhoneNumber,
                client.Email
            },
             commandType: CommandType.StoredProcedure);
        }

        public void UpdateClient(Client client)
        {
            string proc = "dbo.Client_Update";
            using var connection = GetConnection();
            connection.Execute(proc, new
            {
                client.Id,
                client.FirstName,
                client.LastName,
                client.Patronymic,
                client.PhoneNumber,
                client.Email
            },
            commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteClient(Client client)
        {
            string proc1 = "dbo.Client_Delete";
            using var connection = GetConnection();
            connection.Execute(proc1, new
            {
                Id = client.Id
            },
            commandType: CommandType.StoredProcedure
            );
        }


    }
}

