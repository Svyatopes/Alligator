using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Entities
{
    public class OrderReview
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Text { get; set; }
    }
}
