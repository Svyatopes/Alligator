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
    class OrderReviewViewModel : INotifyPropertyChanged
    {
        public OrderReviewViewModel(OrderReviewViewModel OrderReviewModel)
        {
            Id = OrderReviewModel.Id;
            Order = OrderReviewModel.Order;
            //Client = OrderReviewModel.Client;
            Text = OrderReviewModel.Text;
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

        private OrderModel order;

        public OrderModel Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
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

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
       
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
