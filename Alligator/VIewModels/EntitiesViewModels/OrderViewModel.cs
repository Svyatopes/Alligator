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
    public class OrderViewModel: INotifyPropertyChanged
    {
        public OrderViewModel(OrderModel orderModel)
        {
            Id = orderModel.Id;

        }
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ClientModel Client { get; set; }
        public string Address { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
        public List<OrderReviewModel> OrderReviews { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
