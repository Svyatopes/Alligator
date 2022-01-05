using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.Helpers;
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
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientservice;
        public AddNewClient(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientservice = clientService;
        }
        
        public override void Execute(object parameter)
        {
            bool isValid = ClientValidation.TrimAndCheckIsValid(_viewModel.NewClient);
            if (!isValid)
            {
                MessageBox.Show("данные введены НЕКОРРЕКТНО\r\nПроверьте количество введенных символов, и валидность емейла", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var idNewClient = _clientservice.InsertNewClient(_viewModel.NewClient);
            _viewModel.NewClient.Id = idNewClient;
            _viewModel.Clients.Add(_viewModel.NewClient);

            _viewModel.Return.Execute(null);
        }
    }
}
