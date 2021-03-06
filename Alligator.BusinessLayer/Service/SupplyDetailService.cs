using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Service
{
    public class SupplyDetailService : ISupplyDetailService
    {
        private readonly ISupplyDetailRepository _supplyDetailRepository;
        private readonly IProductRepository _productRepository;


        public SupplyDetailService()
        {
            _supplyDetailRepository = new SupplyDetailRepository();
            _productRepository = new ProductRepository();

        }
        public SupplyDetailService(ISupplyDetailRepository fakeSupplyRepository, IProductRepository fakeProductRepository)
        {
            _supplyDetailRepository = fakeSupplyRepository;
            _productRepository = fakeProductRepository;

        }
        public List<SupplyDetailModel> GetAllSupplyDetails()
        {
            var entities = _supplyDetailRepository.GetAllSupplyDetails();
            try
            {
                return CustomMapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
            }
            catch
            {
                return new List<SupplyDetailModel>();
            }

        }

        public List<SupplyDetailModel> GetSupplyDetailBySupplyId(int id)
        {
            var entities = _supplyDetailRepository.GetSupplyDetailBySupplyId(id);
            try
            {
                return CustomMapper.GetInstance().Map<List<SupplyDetailModel>>(entities);
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
            var supplyModel = CustomMapper.GetInstance().Map<List<SupplyDetail>>(supplyDetail);
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
                var supplyModel = CustomMapper.GetInstance().Map<SupplyDetail>(supplyDetail);
                return _supplyDetailRepository.AddSupplyDetail(supplyModel);
            }
            catch
            {
                return -1;
            }


        }
        public List<ProductModel> GetProducts()
        {
            var entities = _productRepository.GetAllProducts();
            try
            {
                return CustomMapper.GetInstance().Map<List<ProductModel>>(entities);
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
                return CustomMapper.GetInstance().Map<ProductModel>(entities);
            }
            catch
            {
                return new ProductModel() { Id = -1 };
            }

        }
    }
}
