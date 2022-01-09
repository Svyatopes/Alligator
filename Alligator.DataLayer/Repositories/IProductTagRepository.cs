using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IProductTagRepository
    {
        int AddProductTag(string name);
        bool DeleteProductTag(ProductTag productTag);
        ProductTag GetProductTagById(int id);
        List<ProductTag> GetProductTags();
        bool UpdateProductTag(ProductTag productTag);
    }
}