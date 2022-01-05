using Alligator.DataLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Repositories
{

    public class OrderDetailRepository : BaseRepository, IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailById(int id)
        {
            using var connection = ProvideConnection();
            var orderDetailDictionary = new Dictionary<int, OrderDetail>();
            return connection.Query<OrderDetail, Order, Product, OrderDetail>
            ("dbo.OrderDetail_SelectById", (orderdetail, order, product) =>
            {
                orderdetail.Order = order;
                orderdetail.Product = product;
                return orderdetail;
            },
            new { Id = id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id")
            .FirstOrDefault();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            using var connection = ProvideConnection();
            var orderDetailDictionary = new Dictionary<int, OrderDetail>();
            return connection.Query<OrderDetail, Order, Product, OrderDetail>
            ("dbo.OrderDetail_SelectByOrderId", (orderdetail, order, product) =>
            {
                orderdetail.Order = order;
                orderdetail.Product = product;
                return orderdetail;
            },
            new { OrderId = id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id")
            .Distinct().ToList();
        }

        public List<OrderDetail> GetOrderDetailsByProductId(int id)
        {
            using var connection = ProvideConnection();
            var orderDetailDictionary = new Dictionary<int, OrderDetail>();
            return connection.Query<OrderDetail, Order, Product, OrderDetail>
            ("dbo.OrderDetail_SelectByProductId", (orderdetail, order, product) =>
            {
                orderdetail.Order = order;
                orderdetail.Product = product;
                return orderdetail;
            },
            new { ProductId = id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id")
            .Distinct().ToList();
        }

        public void AddOrderDetail(int amount, int orderId, int productId)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderDetail_Insert";
            connection.Execute(procString,
            new { Amount = amount, OrdertId = orderId, ProductId = productId },
            commandType: CommandType.StoredProcedure);
        }

        public void EditOrderDetail(int id, int amount)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderDetail_Update";
            connection.Execute(procString, new { Id = id, Amount = amount },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderDetail(int id)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderDetail_Delete";
            connection.Execute(procString, new { Id = id },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderDetailByProductId(int id)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderDetail_DeleteByProductId";
            connection.Execute(procString, new { ProductId = id },
            commandType: CommandType.StoredProcedure);
        }
    }
}
