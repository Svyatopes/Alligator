using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;


namespace Alligator.BusinessLayer.Service
{
    public class SupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        public SupplyService()
        {
            _supplyRepository = new SupplyRepository();

        }
        public List<SupplyModel> GetAllSupplies()
        {
            var entities = _supplyRepository.GetSupplies();

            return Mapper.GetInstance().Map<List<SupplyModel>>(entities);
        }

        public SupplyModel GetSupplyById(int id)
        {
            var entities = _supplyRepository.GetSupplyById(id);
            return Mapper.GetInstance().Map<SupplyModel>(entities);
        }

        public void DeleteSupply(int id)
        {
            _supplyRepository.DeleteSupply(id);
        }

        public void UpdateSupply(SupplyModel supply)
        {
            var supplyModel = Mapper.GetInstance().Map<Supply>(supply);
            _supplyRepository.EditSupply(supplyModel); 
        }

        public int InsertSupply(SupplyModel supply)
        {
            var supplyModel = Mapper.GetInstance().Map<Supply>(supply);
            return _supplyRepository.AddSupply(supplyModel);
        }
    }
}



