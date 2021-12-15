using System;
using System.Collections.Generic;

namespace Alligator.DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public string Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<OrderReview> OrderReviews { get; set; }

    }
}
