using Alligator.BusinessLayer.Services;
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
        private ClientService _clientService;
        private ObservableCollection<ClientViewModel> clients;
        private ObservableCollection<CommentViewModel> comments;
        private ClientViewModel selected;
        private CommentViewModel selectedCom;
        private string comment;
        private string firstNameTextNewFirstName;
        private string lastNameTextNewLastName;
        private string patronymicTextNewPatronymic;
        private string phoneNumberTextNewPhoneNumber;
        private string emailTextNewEmail;
        private CommentViewModel selectedComment;
        private bool isSelectedTabItem;
        private bool isEnabledChange;
        private Visibility _allClients;
        private Visibility _clientCard;
        private Visibility _addClient;
        private Visibility _buttonOpenCard;
        public ICommand DeleteClient { get; set; }
        public ICommand AddingClient { get; set; }
       public ICommand OpenClientCard { get; set; }
        public ICommand ComeBack { get; set; }
        public ICommand SaveChanges { get; set; }
        public ICommand DeleteClientInClientCard { get; set; }
        public ICommand AddComment { get; set; }
        public ICommand AddNewClient { get; set; }
        public ICommand DeleteComment { get; set; }
       
        public TabItemClientsViewModel()
        {
            _clientService = new ClientService();
            Clients = new ObservableCollection<ClientViewModel>();
            DeleteClient = new ButtonDeleteClient_AllClients(this, _clientService);
            ComeBack = new ButtonComeBack(this);
            OpenClientCard = new ButtonOpenClientCard(this);
            SaveChanges = new ButtonSaveChanges(this);
            AddingClient = new ButtonAddClient(this);
            DeleteClientInClientCard = new ButtonDeleteClient_ClientCard(this);
            AddComment = new ButtonAddComment(this);
            AddNewClient = new ButtonAddNewClient(this, _clientService);
            DeleteComment = new DeleteComment(this);
           
        }
       
        public bool IsSelectedTabItem
        {
            get { return isSelectedTabItem; }
            set
            {
                isSelectedTabItem = value;
                OnPropertyChanged("IsSelectedTabItem");
            }
        }
        public CommentViewModel  SelectedComment
        {
            get { return selectedComment; }
            set
            {
                selectedComment = value;
                OnPropertyChanged("SelectedComment");
            }
        }
        public ObservableCollection<CommentViewModel> Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChanged("Comments");
            }
        }
        public Visibility ButtonOpenCard
        {
            get { return _buttonOpenCard; }
            set
            {
                _buttonOpenCard = value;
                OnPropertyChanged("ButtonOpenCard");
            }
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
                OnPropertyChanged("AddClient");
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
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public string FirstNameTextNewFirstName
        {
            get { return firstNameTextNewFirstName; }
            set
            {
                firstNameTextNewFirstName = value;
                OnPropertyChanged("FirstNameTextNewFirstName");
            }
        }
        public string LastNameTextNewFirstName
        {
            get { return lastNameTextNewLastName; }
            set
            {
                lastNameTextNewLastName = value;
                OnPropertyChanged("LastNameTextNewFirstName");
            }
        }
        public string PatronymicTextNewPatronymic
        {
            get { return patronymicTextNewPatronymic; }
            set
            {
                patronymicTextNewPatronymic = value;
                OnPropertyChanged("PatronymicTextNewPatronymic");
            }
        }
        public string PhoneNumberTextNewPhoneNumber
        {
            get { return phoneNumberTextNewPhoneNumber; }
            set
            {
                phoneNumberTextNewPhoneNumber = value;
                OnPropertyChanged("PhoneNumberTextNewPhoneNumber");
            }
        }
        public string EmailTextNewEmail
        {
            get { return emailTextNewEmail; }
            set
            {
                emailTextNewEmail = value;
                OnPropertyChanged("EmailTextNewEmail");
            }
        }
    }
}
