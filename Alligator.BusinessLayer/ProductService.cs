using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ActionResult<List<ProductModel>> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                var productsModels = CustomMapper.GetInstance().Map<List<ProductModel>>(products);
                return new ActionResult<List<ProductModel>>(true, productsModels);
            }
            catch (Exception ex)
            {
                return new ActionResult<List<ProductModel>>(false, null) { ErrorMessage = ex.Message };
            }

        }
    }
}
