using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class SupplyDetailModel
    {
        public int Id { get; set; }
        public int SupplyId { get; set; }
        public ProductModel Product { get; set; }
        public int Amount { get; set; }
        
    }
}
