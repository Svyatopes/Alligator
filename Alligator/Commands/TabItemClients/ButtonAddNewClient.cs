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
    class ButtonAddNewClient : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        private ClientService _clientservice;
        public ButtonAddNewClient(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            this.viewModel = viewModel;
            _clientservice = clientService;
        }
        public override void Execute(object parameter)
        {
            ClientModel client = new ClientModel()
            {
                FirstName = viewModel.FirstNameTextNewFirstName,
                LastName = viewModel.LastNameTextNewFirstName,
                Patronymic = viewModel.PatronymicTextNewPatronymic,
                PhoneNumber = viewModel.PhoneNumberTextNewPhoneNumber,
                Email = viewModel.EmailTextNewEmail
            };

            _clientservice.InsertNewClient(client);
            viewModel.Clients = new ObservableCollection<ClientModel>(_clientservice.GetAllClients());

            viewModel.AllClients = Visibility.Visible;
            viewModel.AddClient = Visibility.Collapsed;
        }
    }
}
