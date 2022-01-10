using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
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


        public ActionResult<ProductModel> AddProduct(ProductModel productModel)
        {
            try
            {
                var productInRepository = CustomMapper.GetInstance().Map<Product>(productModel);
                var productId = _productRepository.AddProduct(productInRepository);

                productModel.Id = productId;
                foreach(var productTag in productModel.ProductTags)
                {
                    _productRepository.AddProductTagToProduct(productId, productTag.Id);
                }
                return new ActionResult<ProductModel>(true, productModel);
            }
            catch(Exception ex)
            {
                return new ActionResult<ProductModel>(false, null) { ErrorMessage = ex.Message };
            }
        }

        public bool DeleteProduct(ProductModel product)
        {
            try
            {
                return _productRepository.DeleteProduct(product.Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
