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
        private const string _connString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        //string _connString = "Server=(local);Database=AggregatorAlligator;Integrated Security=true";
        
        public List<Supply> GetSupplies()
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            return sqlConnection
                .Query<Supply>("dbo.Supply_SelectAll"
                ).ToList();            
        }
        public List<Supply> GetSupplyById(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            return sqlConnection
                .Query<Supply>(
                "dbo.Supply_SelectById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
                ).ToList();            
        }

        public void AddSupply(DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            sqlConnection
                .Query<Supply>(
                "dbo.Supply_Insert",
                new { Date = date },
                commandType: CommandType.StoredProcedure
                );
        }
        public void DeleteSupply(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            sqlConnection
                .Query<Supply>(
                "dbo.Supply_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
                );
        }
        public void EditSupply(int id, DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            sqlConnection
                .Query<Supply>(
                "dbo.Supply_Update",
                new { Id = id, Date = date },
                commandType: CommandType.StoredProcedure
                );
        }        
    }
}