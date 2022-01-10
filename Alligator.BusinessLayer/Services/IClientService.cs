using System.Collections.Generic;

namespace Alligator.BusinessLayer.Services
{
    public interface IClientService
    {
        ActionResult<List<ClientModel>> GetAllClients();
        ActionResult<ClientModel> GetClientById(int id);
        int InsertNewClient(ClientModel client);
        bool UpdateClient(ClientModel client);
        bool DeleteClient(ClientModel client);


    }
}