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
        private OrderShortModel _selectedOrder;
        private OrderDetailModel _selectedOrderDetailModel;
        private OrderReviewModel _selectedOrderReviewModel;
        private ProductModel _selectedProduct;
        private ClientModel _selectedClient;
        private readonly OrderService _orderService;
        private readonly OrderReviewService _orderReviewService;
        private readonly OrderDetailService _orderDetailService;
        private readonly ClientService _clientService;
        private string _newReviewText;
        private string _newAdressText;
        private DateTime _newDate;

        public ICommand AddReview { get; set; }
        public ICommand GetOrders { get; set; }
        public ICommand GetOrderInfo { get; set; }
        public ICommand DeleteOrder { get; set; }
        public ICommand AddOrder { get; set; }
        public ICommand OpenAddOrderWindow { get; set; }
        public ICommand OpenOrderInfoWindow { get; set; }
        public ICommand ComeBackFirstWindow { get; set; }
        public TabItemOrdersViewModel()
        {

            _orderService = new OrderService();
            _orderReviewService = new OrderReviewService();
            _orderDetailService = new OrderDetailService();
            _clientService = new ClientService();
            AddReview = new AddReviewCommand(this, _orderReviewService);
            GetOrders = new GetOrdersCommand(this, _orderService);
            DeleteOrder = new DeleteOrderCommand(this, _orderService);
            AddOrder = new AddOrderCommand(this, _orderService);
            OpenAddOrderWindow = new OpenAddOrderWindowCommand(this);
            OpenOrderInfoWindow = new OpenOrderInfoWindowCommand(this);
            ComeBackFirstWindow = new ComeBackFirstWindowCommand(this);

            AllOrders = new ObservableCollection<OrderShortModel>(_orderService.GetOrderssWithoutSensitiveData());
            //OrderDetails = new ObservableCollection<OrderDetailModel>(_orderDetailService.GetOrderDetailsByOrderId(SelectedOrder.Id));
            //OrderReviews = new ObservableCollection<OrderReviewModel>(_orderReviewService.GetOrderReviewModelsByOrderId(SelectedOrder.Id));           
            Clients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
           //Products закомменчен в виду отсутствия productService
            // Products = new ObservableCollection<ProductModel>(_productService.GetProducts());
        }

        public ObservableCollection<OrderShortModel> AllOrders { get; set; }
        public ObservableCollection<OrderDetailModel> OrderDetails { get; set; }
        public ObservableCollection<OrderReviewModel> OrderReviews { get; set; }

        public ObservableCollection<ClientModel> Clients { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }

        public OrderShortModel SelectedOrder
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
