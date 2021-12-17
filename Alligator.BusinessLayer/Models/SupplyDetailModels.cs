using Alligator.DataLayer.Entities;


namespace Alligator.BusinessLayer.Models
{
    public class SupplyDetailModels
    {
        public int Id { get; set; }
        public Supply Supply { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
