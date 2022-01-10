using Alligator.BusinessLayer;
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
    class OrderReviewViewModel : BaseViewModel
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

        private ClientModel _clientModel;

        public ClientModel Client
        {
            get => _clientModel; 
            set
            {
                _clientModel = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        private string _text;
        public string Text
        {
            get => _text; 
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
              
    }
}
