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
    public class OrderReviewRepository : BaseRepository, IOrderReviewRepository
    {
        public OrderReview GetOrderReviewById(int id)
        {
            using var connection = ProvideConnection();
            return connection.Query<OrderReview, Order, Client, OrderReview>
            ("dbo.OrderReview_SelectById", (orderreview, order, client) =>
            {
                orderreview.Order = order;               
                return orderreview;
            },
            new {  id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            FirstOrDefault();
        }

        public List<OrderReview> GetOrderReviewsByOrderId(int id)
        {
            using var connection = ProvideConnection();
            var orderReviewsDictionary = new Dictionary<int, OrderReview>();
            return connection.Query<OrderReview, Order, Client, OrderReview>
            ("dbo.OrderReview_SelectByOrderId", (orderreview, order, client) =>
            {
                orderreview.Order = order;
                return orderreview;
            },
            new { OrderId=id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            Distinct().ToList();
        }

        public void AddOrderReview(string text, int orderId)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderReview_Insert";
            connection.Execute(procString,
            new {text, orderId },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderReview(int id)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderReview_Delete";
            connection.Execute(procString,
            new { id },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderReviewByOrderId(int orderId)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderReview_DeleteByOrderId";
            connection.Execute(procString, new { orderId },
            commandType: CommandType.StoredProcedure);
        }

        public void EditOrderReview(int id, string text)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.OrderReview_Update";
            connection.Execute(procString, new { id, text },
            commandType: CommandType.StoredProcedure);
        }

    }
}

