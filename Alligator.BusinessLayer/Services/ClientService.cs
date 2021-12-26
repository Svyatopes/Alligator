﻿using Alligator.BusinessLayer.Configuration;
using Alligator.DataLayer;
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
        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }
        public List<ClientModel> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            return CustomMapper.GetInstance().Map<List<ClientModel>>(clients);
        }
        public void InsertNewClient(ClientModel client)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var justClient = mapper.Map<Client>(client);
            _clientRepository.InsertClient(justClient);
        }
        public void DeleteClient(int id)
        {
           
            _clientRepository.DeleteClient(id);
        }
    }
}
