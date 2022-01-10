using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
        public List<ProductTagModel> ProductTags { get; set; }

        public bool IsValid()
        {
            if(Name.Length > 100)
                return false;
            return true;
        }
    }
}
