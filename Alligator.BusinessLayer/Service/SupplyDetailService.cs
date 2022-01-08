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
            try
            {
                return Mapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
            }
            catch 
            {
                return new List<SupplyDetailModel>();                
            }
            
        }

        public List<SupplyDetailModel> GetSupplyDetailById(int id)
        {
            var entities = _supplyDetailRepository.GetSupplyDetailBySupplyId(id);
            try
            {
                return Mapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
            }
            catch 
            {
                return new List<SupplyDetailModel>();
            }
            
        }

        public bool DeleteSupplyDetailBySupplyId(int id)
        {
            try
            {
                _supplyDetailRepository.DeleteSupplyDetailBySupplyId(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteSupplyDetailById(int id)
        {
            try
            {
                _supplyDetailRepository.DeleteSupplyDetailById(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSupplyDetail(List<SupplyDetailModel> supplyDetail)
        {
            var supplyModel = Mapper.GetInstance().Map<List<SupplyDetail>>(supplyDetail);
            try
            {
                _supplyDetailRepository.EditSupplyDetail(supplyModel);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public int InsertSupplyDetail(SupplyDetailModel supplyDetail)
        {
            try
            {
                var supplyModel = Mapper.GetInstance().Map<SupplyDetail>(supplyDetail);
                return _supplyDetailRepository.AddSupplyDetail(supplyModel);
            }
            catch 
            {
                return -1;                
            }
            

        }
        public List<ProductModel> GetProduct()
        {
            var entities = _productRepository.GetAllProducts();
            try
            {
                return Mapper.GetInstance().Map<List<ProductModel>>(entities);
            }
            catch 
            {
                return new List<ProductModel>();
            }
            

        }
        public ProductModel GetProductById(int id)
        {
            var entities = _productRepository.GetProductById(id);
            try
            {
                return Mapper.GetInstance().Map<ProductModel>(entities);
            }
            catch 
            {
                return new ProductModel() { Id = -1};                
            }          

        }
    }
}
