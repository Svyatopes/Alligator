using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class OrderViewModel: BaseViewModel
    {
        public OrderViewModel(OrderModel orderModel)
        {
            Id = orderModel.Id;
            Date = orderModel.Date;
            //Client = orderModel.Client;
            Address = orderModel.Address;
            OrderDetails = orderModel.OrderDetails;
            OrderReviews = orderModel.OrderReviews;

        }


        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private DateTime date;
        
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        //private ClientModel clientModel;
        
        //public ClientModel Client
        //{
        //    get { return clientModel; }
        //    set
        //    {
        //        clientModel = value;
        //        OnPropertyChanged(nameof(Client));
        //    }
        //}

        private string address;

        public string Address 
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private List<OrderDetailModel> orderDetails;
        
        public List<OrderDetailModel> OrderDetails 
        {
            get { return orderDetails; }
            set
            {
                orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }

        private List<OrderReviewModel> orderReviews;
        public List<OrderReviewModel> OrderReviews 
        { 
            get { return orderReviews; }
            set
            {
                orderReviews = value;
                OnPropertyChanged(nameof(OrderReviews));
            } 
        }
        
    }
}
