using Alligator.BusinessLayer.Models.Models;
using Alligator.BusinessLayer.Services;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public interface IProductService
    {
        bool Deleteproduct(ProductModel product);
        ActionResult<List<ProductModel>> GetAllproducts();
        ActionResult<ProductModel> GetproductById(int id);
        int InsertNewproduct(ProductModel product);
        bool Updateproduct(ProductModel product);
    }
}