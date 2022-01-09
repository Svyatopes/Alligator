using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;


namespace Alligator.BusinessLayer.Service
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        public SupplyService()
        {
            _supplyRepository = new SupplyRepository();

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
                return Mapper.GetInstance().Map<List<SupplyModel>>(entities);
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
                return Mapper.GetInstance().Map<SupplyModel>(entities);
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
            var supplyModel = Mapper.GetInstance().Map<Supply>(supply);
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
            var supplyModel = Mapper.GetInstance().Map<Supply>(supply);
            try
            {
                return _supplyRepository.AddSupply(supplyModel);
            }
            catch
            {
                return -1;
            }

        }
    }
}



