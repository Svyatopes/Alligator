using Alligator.BusinessLayer.Configuration;
using Alligator.DataLayer;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

      

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }
        public ClientService(IClientRepository fakeClientRepository)
        {
            _clientRepository = fakeClientRepository;
        }

        public List<ClientModel> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            try
            {
                return CustomMapper.GetInstance().Map<List<ClientModel>>(clients);
            }
            catch
            {
                return new List<ClientModel>();
            }

        }

        public ClientModel GetClientById(int id)
        {
            var client = _clientRepository.GetClientById(id);
            return CustomMapper.GetInstance().Map<ClientModel>(client);
        }

        public int InsertNewClient(ClientModel client)
        {
            
            var clientMap = CustomMapper.GetInstance().Map<Client>(client);
            try
            {
                return _clientRepository.InsertClient(clientMap);
            }
            catch
            {
                return -1;
            }

        }

        public void UpdateClient(ClientModel client)
        {
            
            var clientMap = CustomMapper.GetInstance().Map<Client>(client);
            _clientRepository.UpdateClient(clientMap);
        }

        public bool DeleteClient(ClientModel client)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var clientMap = mapper.Map<Client>(client);
            try
            {
                _clientRepository.DeleteClient(clientMap);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
