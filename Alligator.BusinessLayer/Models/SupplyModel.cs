using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alligator.BusinessLayer.Models
{
    public class SupplyModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<SupplyDetailModel> Details { get; set; }
    }
}
