using Alligator.DataLayer.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;
using System;

namespace Alligator.DataLayer.Repositories
{
    public class SupplyRepository
    {
        private const string _connString = "Server=(local);Database=AggregatorAlligator;Integrated Security=true;";
        Supply supply1 = new Supply();
        public List<Supply> GetSupplies()
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            var result = sqlConnection.Query<Supply>(
                "dbo.Supply_SelectAll").ToList();
            return result;
        }
        public Supply GetSupplyById(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            var result = sqlConnection.Query<Supply>("dbo.Supply_SelectById",
                new { Id = id },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return result;
        }

        public void AddSupply(DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            sqlConnection.Execute("dbo.Supply_Insert", new { Date = date },
                 commandType: CommandType.StoredProcedure);
        }
        public void DeleteSupply(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            string procString = "dbo.Supply_Delete";
            sqlConnection.Execute(procString, new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
        public void EditSupply(int id, DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            string procString = "dbo.Supply_Update";
            sqlConnection.Execute(procString, new { Id = id, Date = date },
                commandType: CommandType.StoredProcedure);
        }
    }
}
       

        
