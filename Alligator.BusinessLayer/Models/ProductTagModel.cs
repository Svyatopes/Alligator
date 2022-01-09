namespace Alligator.BusinessLayer.Models
{
    public class ProductTagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductTagModel model &&
                   Id == model.Id &&
                   Name == model.Name;
        }
    }
}
