using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Services;
using Alligator.UI.Commands;
using Alligator.UI.Commands.TabItemClients;
using Alligator.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemClientsViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;
        private readonly CommentService _commentService;
        private readonly OrderService _orderService;

        private ClientModel _selectedClient;
        private string _text;
        private string _comment;
        private CommentModel _selectedComment;
        private Visibility _allClients;
        private Visibility _clientCardVisibility;
        private Visibility _addClient;
        private Visibility _buttonOpenCard;

        private ObservableCollection<CommentModel> _comments;
        private ObservableCollection<OrderModel> _orders;
        public ICommand DeleteClient { get; set; }
        public ICommand AddingClient { get; set; }
        public ICommand OpenClientCard { get; set; }
        public ICommand Return { get; set; }
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
            _orderService = new OrderService();
            Clients = new ObservableCollection<ClientModel>();
            Comments = new ObservableCollection<CommentModel>();
            Orders = new ObservableCollection<OrderModel>();

            DeleteClient = new DeleteClientCommand(this, _clientService, _commentService, _orderService);
            Return = new ReturnCommand(this);
            OpenClientCard = new OpenClientCardCommand(this, _clientService, _commentService,_orderService);
            SaveChanges = new SaveChanges(this, _clientService, _commentService);
            AddingClient = new AddClientPageCommand(this, _clientService);
            AddComment = new AddCommentCommand(this, _commentService);
            AddNewClient = new AddNewClientCommand(this, _clientService);
            DeleteComment = new DeleteCommentCommand(this, _commentService);
            LoadClients = new LoadClientsCommand(this, _clientService);


            AddClient = Visibility.Collapsed;
            ClientCardVisibility = Visibility.Collapsed;
        }
        public ObservableCollection<ClientModel> Clients { get; set; }

       
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public CommentModel SelectedComment
        {
            get { return _selectedComment; }
            set
            {
                _selectedComment = value;
                OnPropertyChanged(nameof(SelectedComment));
            }
        }

        public ObservableCollection<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }


        public ObservableCollection<CommentModel> Comments
        {
            get { return _comments; }   
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }
       
        public Visibility ButtonOpenCard
        {
            get { return _buttonOpenCard; }
            set
            {
                _buttonOpenCard = value;
                OnPropertyChanged(nameof(ButtonOpenCard));
            }
        }
        public Visibility AllClients
        {
            get { return _allClients; }
            set
            {
                _allClients = value;
                OnPropertyChanged(nameof(AllClients));
            }
        }
        public Visibility AddClient
        {
            get { return _addClient; }
            set
            {
                _addClient = value;
                OnPropertyChanged(nameof(AddClient));
            }
        }
        public Visibility ClientCardVisibility
        {
            get { return _clientCardVisibility; }
            set
            {
                _clientCardVisibility = value;
                OnPropertyChanged(nameof(ClientCardVisibility));
            }
        }

        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                ((CommandBase)OpenClientCard).RaiseCanExecuteChanged();
                ((CommandBase)DeleteClient).RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        //TODO rename
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private OrderModel _order;
        public OrderModel Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
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
