using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    class TabItemOrdersDetailViewModel : BaseViewModel
    {
        private ObservableCollection<OrderDetailViewModel> orderdetails;
        public ObservableCollection<OrderDetailViewModel> OrderDetails
        {
            get { return orderdetails; }
            set
            {
                orderdetails = value;
                OnPropertyChanged("OrderDetails");
            }
        }

        public TabItemOrdersDetailViewModel()
        {
            OrderDetails = new ObservableCollection<OrderDetailViewModel>();
        }
    
    }
}
