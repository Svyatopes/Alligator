using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Entities
{
    public class SupplyDetail
    {
        public int Id { get; set; }
        public Supply Supply { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        
    }
}
