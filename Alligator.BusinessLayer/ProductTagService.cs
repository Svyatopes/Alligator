using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class ProductTagService
    {
        private readonly IProductTagRepository _productTagRepository;

        public ProductTagService()
        {
            _productTagRepository = new ProductTagRepository();
        }

        public ProductTagService(IProductTagRepository productTagRepository)
        {
            _productTagRepository = productTagRepository;
        }

        public ActionResult<List<ProductTagModel>> GetAllProductTags()
        {
            try
            {
                var productTags = _productTagRepository.GetProductTags();
                var productTagsModels = CustomMapper.GetInstance().Map<List<ProductTagModel>>(productTags);
                return new ActionResult<List<ProductTagModel>>(true, productTagsModels);
            }
            catch (Exception ex)
            {
                return new ActionResult<List<ProductTagModel>>(false, new List<ProductTagModel>()) { ErrorMessage = ex.Message };
            }
        }

        public ActionResult<ProductTagModel> AddProductTag(string name)
        {
            try
            {
                var id = _productTagRepository.AddProductTag(name);
                var productTagModel = new ProductTagModel() { Id = id, Name = name };
                return new ActionResult<ProductTagModel>(true, productTagModel);
            }
            catch (Exception ex)
            {
                return new ActionResult<ProductTagModel>(false, new ProductTagModel()) { ErrorMessage = ex.Message };
            }

        }

        public bool UpdateProductTag(ProductTagModel productTag)
        {
            var productTagInRepo = CustomMapper.GetInstance().Map<ProductTag>(productTag);
            try
            {
                return _productTagRepository.UpdateProductTag(productTagInRepo);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProductTag(ProductTagModel productTag)
        {
            var productTagInRepo = CustomMapper.GetInstance().Map<ProductTag>(productTag);
            try
            {
                return _productTagRepository.DeleteProductTag(productTagInRepo);
            }
            catch
            {
                return false;
            }
        }

    }
}
