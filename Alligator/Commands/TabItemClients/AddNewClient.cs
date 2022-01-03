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
        private TabItemClientsViewModel _viewModel;
        private ClientService _clientservice;
        public AddNewClient(TabItemClientsViewModel viewModel, ClientService clientService)
        {
           _viewModel = viewModel;
            _clientservice = clientService;
        }
        //public override bool CanExecute(object parameter)
        //{
        //bool canExecute = TextBoxesValidation.ClientsNameValidation(viewModel.NewClient.FirstName) &&
        //                  TextBoxesValidation.ClientsNameValidation(viewModel.NewClient.LastName) &&
        //                  TextBoxesValidation.ClientsNameValidation(viewModel.NewClient.Patronymic);
        //    return canExecute;

        //}
        public override void Execute(object parameter)
        {
           

            bool canExecute = TextBoxesValidation.ClientsNameValidation(_viewModel.NewClient.FirstName) &&
                  TextBoxesValidation.ClientsNameValidation(_viewModel.NewClient.LastName) &&
                  TextBoxesValidation.PhoneNumberValidation(_viewModel.NewClient.PhoneNumber)&&
                  TextBoxesValidation.EmailValidation(_viewModel.NewClient.Email) &&
                  TextBoxesValidation.ClientsNameValidation(_viewModel.NewClient.Patronymic);
            if (!canExecute)
            {
                
                var userAnswer = MessageBox.Show ("Корректно ли введены данные? ", "Проверь ну", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (userAnswer == MessageBoxResult.No)
                {
                    return;
                }

            }
           
            var Fname = _viewModel.NewClient.FirstName;
            Fname = Fname.Trim();
            var clientt = new ClientModel()
            {
                FirstName = Fname,
                LastName = _viewModel.NewClient.LastName.Trim(),
                Patronymic = _viewModel.NewClient.Patronymic.Trim(),
                PhoneNumber = _viewModel.NewClient.PhoneNumber.Trim(),
                Email = _viewModel.NewClient.Email.Trim()
            };
            
            _clientservice.InsertNewClient(clientt);
            _viewModel.Clients.Clear();
            foreach(var client in _clientservice.GetAllClients())
            {
                _viewModel.Clients.Add(client); 
            }
            _viewModel.AllClients = Visibility.Visible;
            _viewModel.AddClient = Visibility.Collapsed;
        }
    }
}
