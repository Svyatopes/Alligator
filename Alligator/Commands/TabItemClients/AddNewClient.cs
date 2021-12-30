using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    class AddNewClient : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        private ClientService _clientservice;
        public AddNewClient(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            this.viewModel = viewModel;
            _clientservice = clientService;
        }
        public override void Execute(object parameter)
        {
            //TODO: verify all fields of NewClient to CORRECT filling by user
            var Fname = viewModel.NewClient.FirstName.Trim();
            var clientt = new ClientModel()
            {
                FirstName = Fname,
                LastName = viewModel.NewClient.LastName.Trim(),
                Patronymic = viewModel.NewClient.Patronymic.Trim(),
                PhoneNumber = viewModel.NewClient.PhoneNumber.Trim(),
                Email = viewModel.NewClient.Email.Trim()
            };
            
            _clientservice.InsertNewClient(clientt);
            viewModel.Clients.Clear();
            foreach(var client in _clientservice.GetAllClients())
            {
                viewModel.Clients.Add(client); 
            }
            viewModel.AllClients = Visibility.Visible;
            viewModel.AddClient = Visibility.Collapsed;
        }
    }
}
