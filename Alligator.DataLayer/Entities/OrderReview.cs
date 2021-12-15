namespace Alligator.DataLayer.Entities
{
    public class OrderReview
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Client Client { get; set; }
        public string Text { get; set; }
    }
}
