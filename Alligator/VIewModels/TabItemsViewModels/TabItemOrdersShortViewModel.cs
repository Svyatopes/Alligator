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
    public class TabItemOrdersShortViewModel : BaseViewModel
    {

        private ObservableCollection<OrderViewShortModel> orders;
        public ObservableCollection<OrderViewShortModel> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public TabItemOrdersShortViewModel()
        {
            Orders = new ObservableCollection<OrderViewShortModel>();
        }
    }
}

