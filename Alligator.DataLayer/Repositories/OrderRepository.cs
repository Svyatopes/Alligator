﻿using Alligator.DataLayer.Entities;
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
    public class OrderRepository : BaseRepository, IOrderRepository
    {

        public List<Order> GetAllOrders()
        {
            using var connection = ProvideConnection();
            var orderDictionary = new Dictionary<int, Order>();
            return connection.Query<Order, Client, Order>("dbo.Order_SelectAll", (order, client) =>
            {
                order.Client = client;

                return order;
            },
            commandType: CommandType.StoredProcedure)
            .ToList();
        }

        public Order GetOrderById(int id)
        {
            using var connection = ProvideConnection();
            return connection.Query<Order, Client, Order>("dbo.Order_SelectById", (order, client) =>
            {
                order.Client = client;

                return order;
            },
            new { id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            FirstOrDefault();
        }

        public List<Order> GetOrdersByClientId(int id)
        {
            using var connection = ProvideConnection();
            var orderDictionary = new Dictionary<int, Order>();
            return connection.Query<Order, Client, Order>
            ("dbo.Order_SelectByClientId", (order, client) =>
            {
                order.Client = client;
                return order;
            },
            new { id },
            commandType: CommandType.StoredProcedure,
            splitOn: "Id").
            Distinct().ToList();
        }


        public int AddOrder(DateTime date, int clientId, string address)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.Order_Insert";
            return connection.QueryFirstOrDefault<int>(procString,
            new { date,clientId, address },
            commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrder(int id)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.Order_Delete";
            connection.Execute(procString,
            new {id },
            commandType: CommandType.StoredProcedure);
        }

        public void EditOrder(Order editedOrder)
        {
            using var connection = ProvideConnection();
            string procString = "dbo.Order_Update";
            connection.Execute(procString,
            new { Date=editedOrder.Date, Id= editedOrder.Id, ClientId=editedOrder.Client.Id, editedOrder.Address },
            commandType: CommandType.StoredProcedure);
        }
        public void DeleteOrdersByClientId(int clientId)
        {
            string proc = "dbo.Order_DeleteAllOrdersByClientId";
            using var connection = ProvideConnection();
            connection.Execute(proc, new
            { ClientId = clientId },
            commandType: CommandType.StoredProcedure);
        }

    }
}
