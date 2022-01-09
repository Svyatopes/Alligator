namespace Alligator.BusinessLayer.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryModel model &&
                   Id == model.Id &&
                   Name == model.Name;
        }
    }
}
