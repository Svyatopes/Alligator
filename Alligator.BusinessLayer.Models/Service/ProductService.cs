using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models.Models;
using Alligator.BusinessLayer.Services;
using Alligator.DataLayer;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Models
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
      

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }


        public ActionResult<List<ProductModel>> GetAllproducts()
        {
            var products = _productRepository.GetAllProducts();
            try
            {
                return new ActionResult<List<ProductModel>>(true, CustomMapper.GetInstance().Map<List<ProductModel>>(products));
            }
            catch (Exception exception)
            {
                return new ActionResult<List<ProductModel>>(false, new List<ProductModel>()) { ErrorMessage = exception.Message };
            }

        }
        public ActionResult<ProductModel> GetproductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            try
            {
                return new ActionResult<ProductModel>(true, CustomMapper.GetInstance().Map<ProductModel>(product));
            }
            catch (Exception exception)
            {
                return new ActionResult<ProductModel>(false, new ProductModel()) { ErrorMessage = exception.Message };
            }
        }
        public int InsertNewproduct(ProductModel product)
        {

            var productMap = CustomMapper.GetInstance().Map<Product>(product);
            try
            {
                return _productRepository.AddProduct(productMap);
            }
            catch
            {
                return -1;
            }

        }
        public bool Updateproduct(ProductModel product)
        {

            var productMap = CustomMapper.GetInstance().Map<Product>(product);
            try
            {
                _productRepository.EditProduct(productMap);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Deleteproduct(ProductModel product)
        {

            var productMap = CustomMapper.GetInstance().Map<Product>(product);
            try
            {
                _productRepository.DeleteProduct(productMap.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
