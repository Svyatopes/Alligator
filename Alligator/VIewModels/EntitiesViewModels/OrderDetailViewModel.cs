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
    class OrderDetailViewModel: INotifyPropertyChanged
    {
        public OrderDetailViewModel(OrderDetailModel OrderDetailModel)
        {
            Id = OrderDetailModel.Id;
            Order = OrderDetailModel.Order;
            Product = OrderDetailModel.Product;
            Amount = OrderDetailModel.Amount;
        }

        private int id;
        
        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        private OrderModel order;
        
        public OrderModel Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        private ProductModel product;
        
        public ProductModel Product 
        { 
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            } 
        }

        private int amount;

        public int Amount 
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
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
