using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
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
