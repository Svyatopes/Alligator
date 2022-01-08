using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using Alligator.UI.Commands.TabItemOrders;
using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemOrdersViewModel : BaseViewModel
    {
       
        private OrderModel _selectedOrder;
        private OrderDetailModel _selectedOrderDetailModel;
        private OrderReviewModel _selectedOrderReviewModel;
        private OrderDetailModel _selectedNewOrderDetailModel;
        private OrderReviewModel _selectedNewOrderReviewModel;
        private ProductModel _selectedProduct;
        private ClientModel _selectedClient;
        private readonly OrderService _orderService;
        private readonly OrderReviewService _orderReviewService;
        private readonly OrderDetailService _orderDetailService;
        private readonly ClientService _clientService;
        private string _newReviewText;
        private string _newAdressText;
        private DateTime _newDate;

        public ICommand AddReviewWindowOfOrderInfo { get; set; }
        public ICommand DeleteReviewWindowOfOrderInfo { get; set; }
        public ICommand GetOrders { get; set; }
        public ICommand GetOrderInfo { get; set; }
        public ICommand DeleteOrderWindowOfAllOrders { get; set; }
        public ICommand DeleteOrderWindowOfOrderInfo { get; set; }
        public ICommand AddOrder { get; set; }
        public ICommand SaveChangesWindowOfOrderInfo { get; set; }
        public ICommand OpenAddOrderWindow { get; set; }
        public ICommand OpenOrderInfoWindow { get; set; }
        public ICommand ComeBackFirstWindow { get; set; }
        public ICommand AddReviewWindowOfAddOrder { get; set; }
        public ICommand DeleteReviewWindowOfAddOrder { get; set; }
        public ICommand AddProductWindowOfAddOrder { get; set; }
        public TabItemOrdersViewModel()
        {

            _orderService = new OrderService();
            _orderReviewService = new OrderReviewService();
            _orderDetailService = new OrderDetailService();
            _clientService = new ClientService();

            AllOrders = new ObservableCollection<OrderModel>();                               
            Clients = new ObservableCollection<ClientModel>();
            Products = new ObservableCollection<ProductModel>();

            AddReviewWindowOfOrderInfo = new AddReviewWindowOfOrderInfoCommand(this, _orderReviewService);
            DeleteReviewWindowOfOrderInfo = new DeleteReviewWindowOfOrderInfoCommand(this, _orderReviewService);
            GetOrders = new GetOrdersCommand(this, _orderService);
            DeleteOrderWindowOfAllOrders = new DeleteOrderWindowOfAllOrdersCommand(this, _orderService, _orderDetailService, _orderReviewService);
            DeleteOrderWindowOfOrderInfo=new DeleteOrderWindowOfOrderInfoCommand(this, _orderService, _orderDetailService, _orderReviewService);
            AddOrder = new AddOrderCommand(this, _orderService, _orderReviewService, _orderDetailService);
            SaveChangesWindowOfOrderInfo = new SaveChangesWindowOfOrderInfoCommand(this, _orderService, _orderDetailService, _orderReviewService);
            OpenAddOrderWindow = new OpenAddOrderWindowCommand(this, _clientService);
            OpenOrderInfoWindow = new OpenOrderInfoWindowCommand(this, _orderService);
            ComeBackFirstWindow = new ComeBackFirstWindowCommand(this);
            AddReviewWindowOfAddOrder = new AddReviewWindowOfAddOrderCommand(this);
            DeleteReviewWindowOfAddOrder = new DeleteReviewWindowOfAddOrderCommand(this);
            AddProductWindowOfAddOrder = new AddProductWindowOfAddOrderCommand(this);


        }
        
        public ObservableCollection<OrderModel> AllOrders { get; set; }
        private ObservableCollection<OrderDetailModel> _orderDetails;
        public ObservableCollection<OrderDetailModel> OrderDetails
        {
            get { return _orderDetails; }
            set
            {
                _orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }

        private ObservableCollection<OrderReviewModel> _orderReviews;
        public ObservableCollection<OrderReviewModel> OrderReviews
        {
            get { return _orderReviews; }
            set
            {
                _orderReviews = value;
                OnPropertyChanged(nameof(OrderReviews));
            }
        }

        private ObservableCollection<OrderDetailModel> _newOrderDetails;
        public ObservableCollection<OrderDetailModel> NewOrderDetails
        {
            get { return _newOrderDetails; }
            set
            {
                _orderDetails = value;
                OnPropertyChanged(nameof(NewOrderDetails));
            }
        }

        private ObservableCollection<OrderReviewModel> _newOrderReviews;
        public ObservableCollection<OrderReviewModel> NewOrderReviews
        {
            get { return _newOrderReviews; }
            set
            {
                _orderReviews = value;
                OnPropertyChanged(nameof(NewOrderReviews));
            }
        }

        private OrderModel _newOrder;
        public OrderModel NewOrder
        {
            get { return _newOrder; }
            set
            {
                _newOrder = value;
                OnPropertyChanged(nameof(NewOrder));
            }
        }

        private ObservableCollection<ClientModel> _clients;
        public ObservableCollection<ClientModel> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
        private ObservableCollection<ProductModel> _products;
        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public OrderModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public OrderDetailModel SelectedOrderDetail
        {
            get { return _selectedOrderDetailModel; }
            set
            {
                _selectedOrderDetailModel = value;
                OnPropertyChanged(nameof(SelectedOrderDetail));
            }
        }
        public OrderReviewModel SelectedOrderReview
        {
            get { return _selectedOrderReviewModel; }
            set
            {
                _selectedOrderReviewModel = value;
                OnPropertyChanged(nameof(SelectedOrderReview));
            }
        }

        public OrderDetailModel SelectedNewOrderDetail
        {
            get { return _selectedNewOrderDetailModel; }
            set
            {
                _selectedOrderDetailModel = value;
                OnPropertyChanged(nameof(SelectedNewOrderDetail));
            }
        }
        public OrderReviewModel SelectedNewOrderReview
        {
            get { return _selectedNewOrderReviewModel; }
            set
            {
                _selectedOrderReviewModel = value;
                OnPropertyChanged(nameof(SelectedNewOrderReview));
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

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }


        public string NewReviewText
        {
            get { return _newReviewText; }
            set
            {
                _newReviewText = value;
                OnPropertyChanged(nameof(NewReviewText));
            }
        }

        public string NewAdressText
        {
            get { return _newAdressText; }
            set
            {
                _newAdressText = value;
                OnPropertyChanged(nameof(NewAdressText));
            }
        }

        public DateTime NewDate
        {
            get { return _newDate; }
            set
            {
                _newDate = value;
                OnPropertyChanged(nameof(NewDate));
            }
        }

        private string _newAmount;
        public string NewAmount
        {
            get { return _newAmount; }
            set
            {
                _newAmount = value;
                OnPropertyChanged(nameof(NewAmount));
            }
        }
        private Visibility _allOrdersWindow;
        public Visibility OrdersWindowVisibility
        {
            get
            {
                return _allOrdersWindow;
            }
            set
            {
                _allOrdersWindow = value;

                OnPropertyChanged(nameof(OrdersWindowVisibility));
            }
        }
        private Visibility _ordersInfoWindow;
        public Visibility OrdersInfoWindowVisibility
        {
            get
            {
                return _ordersInfoWindow;
            }
            set
            {
                _ordersInfoWindow = value;

                OnPropertyChanged(nameof(OrdersInfoWindowVisibility));
            }
        }
        private Visibility _addOrderWindow;
        public Visibility AddOrderWindowVisibility
        {
            get
            {
                return _addOrderWindow;
            }
            set
            {
                _addOrderWindow = value;

                OnPropertyChanged(nameof(AddOrderWindowVisibility));
            }
        }
    }
}
