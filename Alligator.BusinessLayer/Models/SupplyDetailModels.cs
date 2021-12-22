using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class SupplyDetailModels
    {
        public int Id { get; set; }
        public Supply Supply { get; set; }
        public List<Product> Product { get; set; }
        public int Amount { get; set; }
    }
}
