using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
{
    class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductModel> GetAllProduct()
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
