using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using AutoMapper;


namespace Alligator.BusinessLayer.Configuration
{
    public class SupplyMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitCustomMapper();
            return _instance;
        }
        private static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplyDetail, SupplyDetailModel>();
                
            }));
        }
    }
}
