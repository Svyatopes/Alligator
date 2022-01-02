using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SuppliesViewModel : BaseViewModel
    {
        private int _id;
        private DateTime _date;
        private List<SupplyDetailModel> _details;


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

        public List<SupplyDetailModel> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
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
