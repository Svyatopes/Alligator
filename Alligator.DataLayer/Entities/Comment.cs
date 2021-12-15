namespace Alligator.DataLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public string Text { get; set; }
    }
}
