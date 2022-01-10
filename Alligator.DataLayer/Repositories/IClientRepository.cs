using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IClientRepository
    {
        void DeleteClient(Client client);
        List<Client> GetAllClients();
        Client GetClientByCommentId(int id);
        Client GetClientById(int id);
        int InsertClient(Client client);
        void UpdateClient(Client client);
    }
}