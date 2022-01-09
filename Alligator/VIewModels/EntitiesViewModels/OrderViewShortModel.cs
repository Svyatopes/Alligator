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
    public class OrderViewShortModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

      
        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }     
    }   
}
