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
   public  class RepositoryOrderReview
    {

        //private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        private const string _connectionString = "Data Source=Local;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

        public List<OrderReview> GetAllOrderReview()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var orderReviewDictionary = new Dictionary<int, OrderReview>();
            return connection.Query<OrderReview, Order, OrderReview>("dbo.OrderReview_SelectAll", (orderreview, order) =>
            {
                orderreview.Order = order;

                return orderreview;
            }, commandType: CommandType.StoredProcedure,
              splitOn: "Id")
                .Distinct()
                .ToList();
        }

        public OrderReview GetOrderReviewById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<OrderReview, Order, OrderReview>("dbo.OrderReview_SelectById", (orderreview, order) =>
            {
                orderreview.Order = order;

                return orderreview;
            },
            new { Id = id },
            commandType: CommandType.StoredProcedure,
             splitOn: "Id").FirstOrDefault();
        }

        public OrderReview GetOrderReviewByOrderId(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<OrderReview, Order, OrderReview>("dbo.OrderReview_SelectByOrderId", (orderreview, order) =>
            {
                orderreview.Order = order;

                return orderreview;
            },
            new { OrderId = id },
            commandType: CommandType.StoredProcedure,
             splitOn: "Id").FirstOrDefault();
        }

        public void AddOrderReview(string text, int orderId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string procString = "dbo.OrderReview_Insert";
            connection.Execute(procString, new { Text = text, OrdertId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderReview(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string procString = "dbo.OrderReview_Delete";
            connection.Execute(procString, new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
        public void DeleteOrderReviewByOrderId(int orderId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string procString = "dbo.OrderReview_DeleteByOrderId";
            connection.Execute(procString, new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public void EditOrderReview( int id, string text)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string procString = "dbo.OrderReview_Update";
            connection.Execute(procString, new {  Id = id, Text = text },
                commandType: CommandType.StoredProcedure);
        }

    }
}

