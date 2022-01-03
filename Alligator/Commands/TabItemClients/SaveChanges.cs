using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Services;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    public class SaveChanges : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        public SaveChanges(TabItemClientsViewModel viewModel, ClientService clientService, CommentService commentService)
        {
            _viewModel = viewModel;
            _commentService = commentService;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
            bool canExecute = TextBoxesValidation.ClientsNameValidation(_viewModel.SelectedClient.FirstName) &&
                   TextBoxesValidation.ClientsNameValidation(_viewModel.SelectedClient.LastName) &&
                   TextBoxesValidation.PhoneNumberValidation(_viewModel.SelectedClient.PhoneNumber) &&
                   TextBoxesValidation.EmailValidation(_viewModel.SelectedClient.Email) &&
                   TextBoxesValidation.ClientsNameValidation(_viewModel.SelectedClient.Patronymic);
            if (!canExecute)
            {

                var userAnswer = MessageBox.Show("Корректно ли введены данные? ", "Проверь ну", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (userAnswer == MessageBoxResult.No)
                {
                    return;
                }

            }
            _clientService.UpdateClient(_viewModel.SelectedClient);
            _viewModel.Clients.Clear();
            foreach (var item in _clientService.GetAllClients())
            {
                _viewModel.Clients.Add(item);
            }
           
            _viewModel.AllClients = Visibility.Visible;
            _viewModel.ClientCardVisibility = Visibility.Collapsed;
            _viewModel.SelectedClient = _viewModel.EditableClient;

        }
    }
}
