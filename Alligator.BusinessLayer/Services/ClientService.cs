﻿using Alligator.BusinessLayer.Configuration;
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
            ClientModel client1;
            Mapper mapper = CustomMapper.GetInstance();
            var clientMap = mapper.Map<Client>(client);
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
            Mapper mapper = CustomMapper.GetInstance();
            var clientMap = mapper.Map<Client>(client);

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
