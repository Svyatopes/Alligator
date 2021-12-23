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
    class OrderDetailViewModel: BaseViewModel
    {
        public OrderDetailViewModel(OrderDetailModel OrderDetailModel)
        {
            Id = OrderDetailModel.Id;
            Order = OrderDetailModel.Order;
            //Product = OrderDetailModel.Product;
            Amount = OrderDetailModel.Amount;
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

        //private ProductModel product;
        
        //public ProductModel Product 
        //{ 
        //    get { return product; }
        //    set
        //    {
        //        product = value;
        //        OnPropertyChanged(nameof(Product));
        //    } 
        //}

        private int amount;

        public int Amount 
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

       
    }
}
