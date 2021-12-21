using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using AutoMapper;

namespace Alligator.BusinessLayer.Configuration
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitializeInstance();
            return _instance;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductTag, ProductTagModel>();
                cfg.CreateMap<ProductTagModel, ProductTag>();

                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<CategoryModel, Category>();
            }));
        }
    }
}
