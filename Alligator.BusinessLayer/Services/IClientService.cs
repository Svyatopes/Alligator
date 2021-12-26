using System.Collections.Generic;

namespace Alligator.BusinessLayer.Services
{
    public interface IClientService
    {
        List<ClientModel> GetAllClients();
    }
}