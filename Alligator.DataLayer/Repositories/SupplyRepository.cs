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

        public List<Supply> GetSupplies()
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.Supply_SelectAll";
            return sqlConnection
                .Query<Supply>(dbo)
                .ToList();
        }

        public List<SupplyDetail> GetSupplyById(Supply id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.Supply_SelectById";
            return sqlConnection
                .Query<SupplyDetail>(
                    dbo,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                )
                .ToList();
        }

        public void AddSupply(DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.Supply_Insert";
            sqlConnection
                .Execute(
                    dbo,
                    new { Date = date },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteSupply(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.Supply_Delete";
            sqlConnection
                .Execute(
                    dbo,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void EditSupply(int id, DateTime date)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.Supply_Update";
            sqlConnection
                .Execute(
                    dbo,
                    new { Id = id, Date = date },
                    commandType: CommandType.StoredProcedure
                );
        }
    }
}