using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SuppliesViewModel : BaseViewModel
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


        private List<SupplyDetailModel> _details;

        public List<SupplyDetailModel> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
    }
}
