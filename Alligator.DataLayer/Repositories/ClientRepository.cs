using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class ClientRepository
    {

       // private const string _connection = "Data Source=(Local);Database=Alligator.DB;Integrated Security=True;";/* "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";*/
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

        public void DeleteClient(Client client)
        {
            string proc1 = "dbo.Client_Delete";
            using var connection = new SqlConnection(_connection);
            connection.Open();
            connection.Execute(proc1, new
            {
                Id = client.Id
            },
            commandType: CommandType.StoredProcedure
            );
        }


    }
}

