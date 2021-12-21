using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public OrderModel Order { get; set; }
       // public ProductModel Product { get; set; }
        public int Amount { get; set; }
    }
}
