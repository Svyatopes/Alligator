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

        public ActionResult<List<ClientModel>> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            try
            {
                return new ActionResult<List<ClientModel>>(true, CustomMapper.GetInstance().Map<List<ClientModel>>(clients));
            }
            catch (Exception exception)
            {
                return new ActionResult<List<ClientModel>>(false, null) { ErrorMessage = exception.Message };
            }

        }

        public ActionResult<ClientModel> GetClientById(int id)
        {
            var client = _clientRepository.GetClientById(id);
            try
            {
                return new ActionResult<ClientModel>(true, CustomMapper.GetInstance().Map<ClientModel>(client));
            }
            catch(Exception exception)
            {
                return new ActionResult<ClientModel>(false, null) { ErrorMessage = exception.Message };
            }
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

        public bool UpdateClient(ClientModel client)
        {
           
            var clientMap = CustomMapper.GetInstance().Map<Client>(client);
            try
            {
                _clientRepository.UpdateClient(clientMap);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteClient(ClientModel client)
        {
           
            var clientMap = CustomMapper.GetInstance().Map<Client>(client);
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
