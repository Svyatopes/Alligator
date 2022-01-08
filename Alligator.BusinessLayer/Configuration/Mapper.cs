using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using AutoMapper;


namespace Alligator.BusinessLayer.Configuration
{
    public class Mapper
    {
        private static AutoMapper.Mapper _instance;

        public static AutoMapper.Mapper GetInstance()
        {
            if (_instance == null)
                InitCustomMapper();
            return _instance;
        }
        private static void InitCustomMapper()
        {
            _instance = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supply, SupplyModel>();
                cfg.CreateMap<SupplyModel, Supply>();
                cfg.CreateMap<SupplyDetail, SupplyDetailModel>();
                cfg.CreateMap<SupplyDetailModel, SupplyDetail>();                
                cfg.CreateMap<ProductModel, Product>();                
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<Category, CategoryModel>();      
                cfg.CreateMap<CategoryModel, Category>();                
                
            }));
        }
    }
}
