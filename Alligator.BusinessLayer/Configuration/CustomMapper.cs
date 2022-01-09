using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using AutoMapper;
namespace Alligator.BusinessLayer.Configuration
{
    {
        private static Mapper _instance;
    public static class CustomMapper

        public static Mapper GetInstance()
            if (_instance == null)
        {
            return _instance;
                InitializeInstance();

        }
        private static void InitializeInstance()
            _instance = new Mapper(new MapperConfiguration(cfg =>
        {
            {
                cfg.CreateMap<ProductTag, ProductTagModel>();
                cfg.CreateMap<ProductTagModel, ProductTag>();
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<Order, OrderShortModel>();
                cfg.CreateMap<OrderShortModel, Order>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<OrderModel, Order>();
                cfg.CreateMap<OrderDetail, OrderDetailModel>();
                cfg.CreateMap<OrderReview, OrderReviewModel>();
                cfg.CreateMap<OrderDetailModel, OrderDetail>();
                cfg.CreateMap<OrderReviewModel, OrderReview>();
                cfg.CreateMap<ClientModel, Client>();
                cfg.CreateMap<Client, ClientModel>();


                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();

                cfg.CreateMap<Comment, CommentModel>();
                cfg.CreateMap<CommentModel, Comment>();
            }));
        }
    }
}
