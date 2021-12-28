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
        private readonly ClientRepository _clientRepository;

        //TODO: rename "just" to smth with info about how it uses

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public List<ClientModel> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            return CustomMapper.GetInstance().Map<List<ClientModel>>(clients);
        }

        public ClientModel GetClientById(int id)
        {
            var client = _clientRepository.GetClientById(id);
            return CustomMapper.GetInstance().Map<ClientModel>(client);
        }

        public void InsertNewClient(ClientModel client)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var justClient = mapper.Map<Client>(client);
            _clientRepository.InsertClient(justClient);
        }

        public void UpdateClient(ClientModel client)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var justClient = mapper.Map<Client>(client);
            _clientRepository.UpdateClient(justClient);

        }

        public void DeleteClient(ClientModel client)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var justClient = mapper.Map<Client>(client);
            _clientRepository.DeleteClient(justClient);
        }
    }
}
