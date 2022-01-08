using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer;

namespace Alligator.BusinessLayer.Configuration
{
    public static class CustomMapper
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
                cfg.CreateMap<Order, OrderShortModel>();
                cfg.CreateMap<OrderShortModel, Order>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<OrderModel, Order>();
                cfg.CreateMap<OrderDetail, OrderDetailModel>();
                cfg.CreateMap<OrderDetailModel, OrderDetail>();
                cfg.CreateMap<OrderReview, OrderReviewModel>();
                cfg.CreateMap<OrderReviewModel, OrderReview>();
                cfg.CreateMap<Client, ClientModel>();
                cfg.CreateMap<ClientModel, Client>();

                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<Category, CategoryModel>();

                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();

                cfg.CreateMap<Comment, CommentModel>();
                cfg.CreateMap<CommentModel, Comment>();
            }));
        }
    }
}
