using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class OrderReviewModel
    {
        public int Id { get; set; }
        public OrderModel Order { get; set; }
        public ClientModel Client { get; set; }
        public string Text { get; set; }
    }
}
