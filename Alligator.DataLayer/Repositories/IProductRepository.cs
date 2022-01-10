using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        bool AddProductTagToProduct(int productId, int productTagId);
        bool DeleteProduct(int id);
        bool EditProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool RemoveProductTagFromProduct(int productId, int productTagId);
    }
}