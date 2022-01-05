using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class OrderModel: OrderShortModel
    {      
        public List<OrderDetailModel> OrderDetails { get; set; }
        public List<OrderReviewModel> OrderReviews { get; set; }
    }
}
