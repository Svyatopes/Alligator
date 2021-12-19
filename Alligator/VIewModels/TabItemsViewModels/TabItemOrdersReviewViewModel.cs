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
    class TabItemOrdersReviewViewModel : BaseViewModel
    {
        private ObservableCollection<OrderReviewViewModel> orderreviews;

        public ObservableCollection<OrderReviewViewModel> OrderReviews

        {
            get { return orderreviews; }
            set
            {
                orderreviews = value;
                OnPropertyChanged("OrderReviews");
            }
        }

        public TabItemOrdersReviewViewModel()
        {
            OrderReviews = new ObservableCollection<OrderReviewViewModel>();
        }
    }   
}
