﻿using Alligator.BusinessLayer;
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
    public class ButtonSaveChanges : CommandBase
    {
        private readonly TabItemClientsViewModel _viewModel;
        private readonly ClientService _clientService;
        public ButtonSaveChanges(TabItemClientsViewModel viewModel, ClientService clientService)
        {
            _viewModel = viewModel;
            _clientService = clientService;
        }
        public override void Execute(object parameter)
        {
            var updatedClient = (ClientModel)_viewModel.Selected;
            _clientService.UpdateClient(updatedClient);
            _viewModel.AllClients = Visibility.Visible;
            _viewModel.ClientCard = Visibility.Collapsed;
        }
    }
}
