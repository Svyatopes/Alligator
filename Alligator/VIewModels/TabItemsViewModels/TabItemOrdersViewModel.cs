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
    public class TabItemOrdersViewModel: BaseViewModel
    {
        private ObservableCollection<OrderViewModel> orders;
        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public TabItemOrdersViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
        }
    }
}
