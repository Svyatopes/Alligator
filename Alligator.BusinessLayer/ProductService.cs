using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alligator.BusinessLayer
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult<ProductModel> GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                var productModel = CustomMapper.GetInstance().Map<ProductModel>(product);
                return new ActionResult<ProductModel>(true, productModel);
            }
            catch (Exception ex)
            {
                return new ActionResult<ProductModel>(false, null) { ErrorMessage = ex.Message };
            }
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
                foreach (var productTag in productModel.ProductTags)
                {
                    _productRepository.AddProductTagToProduct(productId, productTag.Id);
                }
                return new ActionResult<ProductModel>(true, productModel);
            }
            catch (Exception ex)
            {
                return new ActionResult<ProductModel>(false, null) { ErrorMessage = ex.Message };
            }
        }

        public ActionResult<ProductModel> UpdateProduct(ProductModel productModel)
        {
            try
            {
                var product = CustomMapper.GetInstance().Map<Product>(productModel);

                var previousProductState = _productRepository.GetProductById(productModel.Id);
                
                if(previousProductState.Name != product.Name ||
                    previousProductState.Category.Name != product.Category.Name)
                {
                    var edited =_productRepository.EditProduct(product);
                    if (!edited)
                        throw new Exception("Some error when update product in DB");
                }

                var productTagsToAdd = product.ProductTags.Except(previousProductState.ProductTags);
                foreach (var tag in productTagsToAdd)
                {
                    var added = _productRepository.AddProductTagToProduct(product.Id, tag.Id);
                    if(!added)
                    {
                        throw new Exception("Some error when add producttag to product in DB");
                    }
                }    


                var productTagsToRemove = previousProductState.ProductTags.Except(product.ProductTags);
                foreach (var tag in productTagsToRemove)
                {
                    var removed = _productRepository.RemoveProductTagFromProduct(product.Id, tag.Id);
                    if(!removed)
                    {
                        throw new Exception("Some error when delete producttag from product in DB");
                    }
                }

                return new ActionResult<ProductModel>(true, productModel);
            }
            catch (Exception ex)
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
