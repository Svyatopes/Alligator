using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class SupplyModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<SupplyDetailModel> Detail { get; set; }
    }
}
