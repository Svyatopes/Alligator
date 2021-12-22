using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SuppliesViewModel : INotifyPropertyChanged
    {
        private int _id;
        private DateTime _date;
        private int _amount;
        private ObservableCollection<ProductViewModel> _product;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }        

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        
        public ObservableCollection<ProductViewModel> Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
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
