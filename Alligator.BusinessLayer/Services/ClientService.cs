using Alligator.BusinessLayer.Configuration;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _cllientRepository;
        public List<ClientModel> GetAllClients()
        {
            var clients = _cllientRepository.GetAllClients();
            return CustomMapper.GetInstance().Map<List<ClientModel>>(clients);
        }
    }
}
