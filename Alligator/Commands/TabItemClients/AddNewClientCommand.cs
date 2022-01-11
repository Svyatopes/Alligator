using Alligator.BusinessLayer.Services;
using Alligator.UI.Helpers;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    class AddNewClientCommand : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientservice;

        public AddNewClientCommand(TabItemClientsViewModel viewModel, ClientService clientService)
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
            int idNewClient = _clientservice.InsertNewClient(_viewModel.NewClient);
            if (idNewClient == -1)
            {
                MessageBox.Show("Ошибка при добавлении клиента в базу данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _viewModel.NewClient.Id = idNewClient;
            _viewModel.Clients.Add(_viewModel.NewClient);
            _viewModel.Return.Execute(null);
        }
    }
}
