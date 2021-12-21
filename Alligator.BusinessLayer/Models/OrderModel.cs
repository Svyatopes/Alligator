using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class OrderModel: OrderShortModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }        
        //public ClientModel Client { get; set; }
        public string Address { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
        public List<OrderReviewModel> OrderReviews { get; set; }
    }
}
