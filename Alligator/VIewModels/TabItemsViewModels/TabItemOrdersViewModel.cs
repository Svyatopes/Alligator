using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.Commands.TabItemOrders;
using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemOrdersViewModel: BaseViewModel
    {
        private OrderShortModel _selectedOrder;
       
        private OrderDetailModel _selectedOrderDetailModel;
        private OrderReviewModel _selectedOrderReviewModel;
        private readonly OrderService _orderService;
        private readonly OrderReviewService _orderReviewService;
        private readonly OrderDetailService _orderDetailService;
        private string _newReviewText;

       public ICommand AddReview { get; set; }
        public ICommand GetOrders { get; set; }

        public ICommand GetOrderInfo { get; set; }
        public TabItemOrdersViewModel()
        {
            //AllOrders = new ObservableCollection<OrderShortModel>(_orderService.GetOrderssWithoutSensitiveData());
            //OrderDetail = new ObservableCollection<OrderDetailModel>(_orderDetailService.GetOrderDetailsByOrderId());
            //OrderReview = new ObservableCollection<OrderReviewModel>(_orderReviewService.GetOrderReviewModelsByOrderId());
            //Order = new ObservableCollection<OrderModel>(_orderService.GetOrders());
           
            _orderService = new OrderService();
            _orderReviewService = new OrderReviewService();
            _orderDetailService = new OrderDetailService();
            AddReview = new AddReviewCommand(this, _orderReviewService);
            GetOrders = new GetOrdersCommand(this, _orderService);

        }

        public ObservableCollection<OrderShortModel> AllOrders { get; set; }
        public ObservableCollection<OrderDetailModel> OrderDetails { get; set; }
        public ObservableCollection<OrderReviewModel> OrderReviews { get; set; }
        public ObservableCollection<OrderModel> Order { get; set; }

        //public ObservableCollection<OrderViewModel> Orders
        //{
        //    get { return orders; }
        //    set
        //    {
        //        orders = value;
        //        OnPropertyChanged(nameof(Orders));
        //    }
        //}
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
       
        public string NewReviewText
        {
            get { return _newReviewText; }
            set
            {
                _newReviewText = value;
                OnPropertyChanged(nameof(NewReviewText));
            }
        }

        
    }
}
