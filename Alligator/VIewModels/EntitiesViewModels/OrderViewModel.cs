using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class OrderViewModel: BaseViewModel
    {
       
        private int _id;
        private DateTime _date;
        private ClientModel _clientModel;
        private string _address;
        private ObservableCollection<OrderDetailModel> _orderDetails;
        private ObservableCollection<OrderReviewModel> orderReviews;
        public int Id
        {
            get => _id; 
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        
        public DateTime Date
        {
            get => _date; 
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public ClientModel Client
        {
            get => _clientModel; 
            set
            {
                _clientModel = value;
                OnPropertyChanged(nameof(Client));
            }
        }
      
        public string Address 
        {
            get => _address; 
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public ObservableCollection<OrderDetailModel> OrderDetails 
        {
            get => _orderDetails; 
            set
            {
                _orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }

        public ObservableCollection<OrderReviewModel> OrderReviews 
        {
            get => orderReviews; 
            set
            {
                orderReviews = value;
                OnPropertyChanged(nameof(OrderReviews));
            } 
        }
        
    }
}
