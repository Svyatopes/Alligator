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
        public List<SupplyDetailModels> GetAllSupplyDetails() 
        {
            var entities =  _supplyDetailRepository.GetAllSupplyDetails(); //позвали репозиторий.
                                                                           //Вернули данные как в табличке

            return SupplyMapper.GetInstance().Map<List<SupplyDetailModels>>(entities);

            //var result = new List<SupplyDetailModels>();  ///перегоняем данные из одного списка в другой
            //foreach (var entity in entities)
            //{
            //    result.Add(new SupplyDetailModels
            //    {
            //        Id = entity.Id,
            //        Amount = entity.Amount,
            //        Supply = entity.Supply,
            //        Product = entity.Product


            //    });
               
                
                
            //}
            //return result;
        }
    }
}
