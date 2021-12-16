using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
{
    public class OrderDetailService
    {
        private readonly RepositoryOrderDetail _repositoryOrderdetail;

        public OrderDetailService()
        {
            _repositoryOrderdetail = new RepositoryOrderDetail();
        }

        public OrderDetailModel GetOrderDetailById(int id)
        {
            var orderDetail = _repositoryOrderdetail.GetOrderDetailById(id);
            return CustomMapper.GetInstance().Map<OrderDetailModel>(orderDetail);
        }

        public List<OrderDetailModel> GetOrderDetailsByOrderId(int id)
        {
            var orderDetails = _repositoryOrderdetail.GetOrderDetailsByOrderId(id);
            return CustomMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }

        public List<OrderDetailModel> GetOrderDetailsByProductId(int id)
        {
            var orderDetails = _repositoryOrderdetail.GetOrderDetailsByProductId(id);
            return CustomMapper.GetInstance().Map<List<OrderDetailModel>>(orderDetails);
        }
    }
}
