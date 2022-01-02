using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Service
{
    public class SupplyDetailService
    {
        private readonly ISupplyDetailRepository _supplyDetailRepository;
        private readonly IProductRepository _productRepository;

        public SupplyDetailService()
        {
            _supplyDetailRepository = new SupplyDetailRepository();
            _productRepository = new ProductRepository();

        }
        public List<SupplyDetailModel> GetAllSupplyDetails()
        {
            var entities = _supplyDetailRepository.GetAllSupplyDetails();

            return Mapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
        }

        public List<SupplyDetailModel> GetSupplyDetailById (int id) 
        {
            var entities = _supplyDetailRepository.GetSupplyDetailBySupplyId(id);
            return Mapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
        }

        public void DeleteSupplyDetail(int id)
        {
            _supplyDetailRepository.DeleteSupplyDetail(id);
        }

        public void UpdateSupplyDetail(List<SupplyDetailModel> supplyDetail)
        {
            var supplyModel = Mapper.GetInstance().Map<List<SupplyDetail>>(supplyDetail);
            _supplyDetailRepository.EditSupplyDetail(supplyModel);
        }

        public int InsertSupplyDetail(SupplyDetailModel supplyDetail)
        {
            var supplyModel = Mapper.GetInstance().Map<SupplyDetail>(supplyDetail);
            return _supplyDetailRepository.AddSupplyDetail(supplyModel);
            
        }
        public List<ProductModel> GetProduct()
        {
            var entities = _productRepository.GetAllProducts();

            return Mapper.GetInstance().Map<List<ProductModel>>(entities);            
            
        }   
        public ProductModel GetProductById(int id)
        {
            var entities = _productRepository.GetProductById(id);

            return Mapper.GetInstance().Map<ProductModel>(entities);            
            
        }        
    }
}
