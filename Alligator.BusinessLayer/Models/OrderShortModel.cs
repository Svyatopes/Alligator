using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class OrderShortModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }    
        public string Address { get; set; }
        public int ClientId { get; set; }
    }
}
