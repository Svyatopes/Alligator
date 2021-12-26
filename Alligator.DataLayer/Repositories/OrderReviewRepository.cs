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
    public interface IOrderReviewRepository
    {
        void AddOrderReview(string text, int orderId);
        void DeleteOrderReview(int id);
        void DeleteOrderReviewByOrderId(int orderId);
        void EditOrderReview(int id, string text);
        OrderReview GetOrderReviewById(int id);
        List<OrderReview> GetOrderReviewsByOrderId(int id);
    }

    public class OrderReviewRepository : BaseRepository, IOrderReviewRepository
    {
        public OrderReview GetOrderReviewById(int id)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            return connection.Query<OrderReview, Order, Client, OrderReview>
            ("dbo.OrderReview_SelectById", (orderreview, order, client) =>
            {
                orderreview.Order = order;
                orderreview.Client = client;
                return orderreview;
            },
            new { Id = id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            FirstOrDefault();
        }

        public List<OrderReview> GetOrderReviewsByOrderId(int id)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            var orderReviewsDictionary = new Dictionary<int, OrderReview>();
            return connection.Query<OrderReview, Order, Client, OrderReview>
            ("dbo.OrderReview_SelectByOrderId", (orderreview, order, client) =>
            {
                orderreview.Order = order;
                orderreview.Client = client;
                return orderreview;
            },
            new { OrderId = id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            Distinct().ToList();
        }

        public void AddOrderReview(string text, int orderId)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            string procString = "dbo.OrderReview_Insert";
            connection.Execute(procString,
            new { Text = text, OrdertId = orderId },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderReview(int id)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            string procString = "dbo.OrderReview_Delete";
            connection.Execute(procString,
            new { Id = id },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderReviewByOrderId(int orderId)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            string procString = "dbo.OrderReview_DeleteByOrderId";
            connection.Execute(procString, new { OrderId = orderId },
            commandType: CommandType.StoredProcedure);
        }

        public void EditOrderReview(int id, string text)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            string procString = "dbo.OrderReview_Update";
            connection.Execute(procString, new { Id = id, Text = text },
            commandType: CommandType.StoredProcedure);
        }

    }
}

