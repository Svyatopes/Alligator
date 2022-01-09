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
        private int _id;
        
        public int Id 
        {
            get => _id; 
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            } 
        }

        private OrderModel _order;
        
        public OrderModel Order
        {
            get => _order; 
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private ProductModel _product;

        public ProductModel Product
        {
            get => _product; 
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        private int _amount;

        public int Amount 
        {
            get => _amount; 
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

       
    }
}
