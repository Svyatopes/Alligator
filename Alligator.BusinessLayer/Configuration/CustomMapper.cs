using Alligator.BusinessLayer.Models;
using Alligator.DataLayer;
using Alligator.DataLayer.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientModel>();
                cfg.CreateMap<ClientModel, Client>();

                cfg.CreateMap<Comment, CommentModel>();
                cfg.CreateMap<CommentModel, Comment>();
            }
             ));
        }
    }
}
