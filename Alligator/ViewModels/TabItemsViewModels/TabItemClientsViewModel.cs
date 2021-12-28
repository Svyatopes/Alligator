using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.Commands.TabItemClients;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemClientsViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;

        private ClientModel _selectedClient;
        


        //TODO: naming - underscore for private fields !
        private string text;
        private string comment;
        private CommentModel selectedComment;
        private Visibility _allClients;
        private Visibility _clientCardVisibility;
        private Visibility _addClient;
        private Visibility _buttonOpenCard;

        private ObservableCollection<CommentModel> comments;

        public ICommand DeleteClient { get; set; }
        public ICommand AddingClient { get; set; }
        public ICommand OpenClientCard { get; set; }
        public ICommand ComeBack { get; set; }
        public ICommand SaveChanges { get; set; }
        public ICommand DeleteClientInClientCard { get; set; }
        public ICommand AddComment { get; set; }
        public ICommand AddNewClient { get; set; }
        public ICommand DeleteComment { get; set; }
        public ICommand LoadClients { get; set; }

        public TabItemClientsViewModel()
        {
            _commentService = new CommentService();
            _clientService = new ClientService();
            Clients = new ObservableCollection<ClientModel>();
            Comments = new ObservableCollection<CommentModel>();


            DeleteClient = new ButtonDeleteClient_AllClients(this, _clientService, _commentService);
            ComeBack = new ButtonComeBack(this);
            OpenClientCard = new ButtonOpenClientCard(this, _clientService);
            SaveChanges = new ButtonSaveChanges(this, _clientService);
            AddingClient = new ButtonAddClient(this, _clientService);
            DeleteClientInClientCard = new ButtonDeleteClient_ClientCard(this, _clientService, _commentService);
            AddComment = new ButtonAddComment(this, _commentService);
            AddNewClient = new ButtonAddNewClient(this, _clientService);
            DeleteComment = new DeleteComment(this, _commentService);
            LoadClients = new LoadClients(this, _clientService);


            AddClient = Visibility.Collapsed;
            ClientCardVisibility = Visibility.Collapsed;
        }
        public ObservableCollection<ClientModel> Clients { get; set; }


        //TODO: need to use nameof!
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public CommentModel SelectedComment
        {
            get { return selectedComment; }
            set
            {
                selectedComment = value;
                OnPropertyChanged("SelectedComment");
            }
        }
        public ObservableCollection<CommentModel> Comments
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
        public Visibility ClientCardVisibility
        {
            get { return _clientCardVisibility; }
            set
            {
                _clientCardVisibility = value;
                OnPropertyChanged("ClientCardVisibility");
            }
        }

        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        //TODO rename
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }


        private ClientModel _editableClient;
        public ClientModel EditableClient
        {
            get { return _editableClient; }
            set
            {
                _editableClient = value;
                OnPropertyChanged(nameof(EditableClient));
            }
        }


        private ClientModel _newClient;
        public ClientModel NewClient
        {
            get { return _newClient; }
            set
            {
                _newClient = value;
                OnPropertyChanged(nameof(NewClient));
            }
        }

    }
}
