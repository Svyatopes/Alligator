using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;

namespace Alligator.BusinessLayer.Configuration
{
    public static class OrderMapper
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
                cfg.CreateMap<Order, OrderShortModel>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<OrderDetail, OrderDetailModel>();
                cfg.CreateMap<OrderReview, OrderReviewModel>();
            }));
        }
    }
}
