using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        bool DeleteProduct(int id);
        bool EditProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}