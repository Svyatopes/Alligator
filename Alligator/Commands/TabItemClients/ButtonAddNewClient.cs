using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alligator.UI.Commands.TabItemClients
{
    class ButtonAddNewClient : CommandBase
    {
        private TabItemClientsViewModel viewModel;
        public ButtonAddNewClient(TabItemClientsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.Clients.Add(new ClientViewModel()
            {
                FirstName = viewModel.FirstNameTextNewFirstName,
                LastName = viewModel.LastNameTextNewFirstName,
                Patronymic = viewModel.PatronymicTextNewPatronymic,
                PhoneNumber = viewModel.PhoneNumberTextNewPhoneNumber,
                Email = viewModel.EmailTextNewEmail

            }
                );
            viewModel.AllClients = Visibility.Visible;
            viewModel.AddClient = Visibility.Collapsed;
        }
    }
}
