using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;


namespace Alligator.BusinessLayer.Service
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly ISupplyDetailRepository _supplyDetailRepository;
        
        public SupplyService()
        {
            _supplyRepository = new SupplyRepository();           
            _supplyDetailRepository = new SupplyDetailRepository();

        }
        public SupplyService(ISupplyRepository fakeSupplyRepository)
        {
            _supplyRepository = fakeSupplyRepository;

        }
        public List<SupplyModel> GetAllSupplies()
        {
            var entities = _supplyRepository.GetSupplies();
            try
            {
                return CustomMapper.GetInstance().Map<List<SupplyModel>>(entities);
            }
            catch
            {
                return new List<SupplyModel>();
            }
        }

        public SupplyModel GetSupplyById(int id)
        {
            var entities = _supplyRepository.GetSupplyById(id);
            try
            {
                return CustomMapper.GetInstance().Map<SupplyModel>(entities);
            }
            catch
            {
                return new SupplyModel() { Id = -1 };
            }

        }

        public bool DeleteSupply(int id)
        {
            try
            {
                _supplyRepository.DeleteSupply(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSupply(SupplyModel supply)
        {
            var supplyModel = CustomMapper.GetInstance().Map<Supply>(supply);
            try
            {
                _supplyRepository.EditSupply(supplyModel);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public int InsertSupply(SupplyModel supply)
        {
            var supplyModel = CustomMapper.GetInstance().Map<Supply>(supply);
            
            try
            {
                var idSupplyInDatabase =  _supplyRepository.AddSupply(supplyModel);
                foreach (var item in supply.Details)
                {
                                        
                    item.SupplyId = idSupplyInDatabase;
                    SupplyDetail sd = new SupplyDetail()
                    {
                        Product = new Product()
                        {
                            Id = item.Product.Id,
                            Name = item.Product.Name
                        },
                        Amount = item.Amount,
                        SupplyId = idSupplyInDatabase
                    };
                    var idSupplyDetailInDatabase = _supplyDetailRepository.AddSupplyDetail(sd);
                    if (idSupplyDetailInDatabase == -1)
                    {
                        throw new Exception("Ошибка при добавлении деталей поставки в БД. Попробуйте позже.");
                    }
                }              
                
            return idSupplyInDatabase;
            }
            catch
            {
                return -1;
            }

        }
    }
}



