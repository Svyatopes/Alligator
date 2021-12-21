using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class ProductTagService
    {
        private readonly ProductTagRepository _productTagRepository;

        public ProductTagService()
        {
            _productTagRepository = new ProductTagRepository();
        }

        public List<ProductTagModel> GetAllProductTags()
        {
            var productTags = _productTagRepository.GetProductTags();
            return CustomMapper.GetInstance().Map<List<ProductTagModel>>(productTags);
        }

        public ProductTagModel AddProductTag(string name)
        {
            ProductTagModel productTagModel;
            try
            {
                var id = _productTagRepository.AddProductTag(name);
                productTagModel = new ProductTagModel() { Id = id, Name = name };
            }
            catch
            {
                return null;
            }

            return productTagModel;
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
