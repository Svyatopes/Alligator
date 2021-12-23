using Alligator.UI.Commands.TabItemClients;
using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
   public  class TabItemClientsViewModel   : BaseViewModel
    {
        private ObservableCollection<ClientViewModel> clients;
        
        private ClientViewModel selected;
        private CommentViewModel selectedCom;
        private double allClientsColumnWidth=1;
        private double clientColumnWidth;
        private double clientCardColumnWidth;
        private bool selectedTabClients;
        private Visibility _allClients;
        private Visibility _clientCard;
        private Visibility _addClient;
        public ICommand DeleteClient { get; set; }
        public ICommand AddingClient { get; set; }
       public ICommand OpenClientCard { get; set; }

        public TabItemClientsViewModel()
        {
            Clients = new ObservableCollection<ClientViewModel>();
            DeleteClient = new ButtonDeleteClient_AllClients(this);
            AddingClient = new ButtonAddClient(this);
            OpenClientCard = new ButtonOpenClientCard(this);
        }
        public Visibility AllClients
        {
            get { return _allClients; }
            set
            {
                _allClients = value;
                OnPropertyChanged("AllClients");
            }
        }
        public Visibility AddClient
        {
            get { return _addClient; }
            set
            {
                _addClient = value;
                OnPropertyChanged("AddingClient");
            }
        }
        public Visibility ClientCard
        {
            get { return _clientCard; }
            set
            {
                _clientCard = value;
                OnPropertyChanged("ClientCard");
            }
        }

        public bool SelectedTabClients
        {
            get { return selectedTabClients; }
            set
            {
                selectedTabClients = value;
                OnPropertyChanged("SelectedTabClients");
            }
        }


        public ObservableCollection<ClientViewModel> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        public ClientViewModel Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public CommentViewModel SelectedCom
        {
            get { return selectedCom; }
            set
            {
                selectedCom = value;
                OnPropertyChanged("SelectedCom");
            }
        }

    }
}
