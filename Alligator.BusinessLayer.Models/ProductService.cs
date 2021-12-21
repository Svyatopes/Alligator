using Alligator.BusinessLayer.Models.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductModel> GetAllProducts()
        {
            var entities = _productRepository.GetAllProducts();
            var productList = new List<ProductModel>();

            foreach (var entity in entities)
                productList.Add(new ProductModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    CategoryId = entity.Category.Id
                });
            return productList;
        }
    }
}
