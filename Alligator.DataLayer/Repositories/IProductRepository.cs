using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteCategory(int id);
        void EditProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}