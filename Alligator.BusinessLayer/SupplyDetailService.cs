using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;
namespace Alligator.BusinessLayer
{
    public class SupplyDetailService
    {
        private readonly SupplyDetailRepository _supplyDetailRepository;
        public SupplyDetailService()
        {
            _supplyDetailRepository = new SupplyDetailRepository();

        }
        public List<SupplyDetailModel> GetAllSupplyDetails()
        {
            var entities = _supplyDetailRepository.GetAllSupplyDetails();

            return SupplyMapper.GetInstance().Map<List<SupplyDetailModel>>(entities);


        }
    }
}
