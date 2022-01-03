using Alligator.DataLayer.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;
using System;

namespace Alligator.DataLayer.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private const string _connString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";


        public List<Supply> GetSupplies()
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.Supply_SelectAll";
            return sqlConnection
                .Query<Supply>(procName,
                commandType: CommandType.StoredProcedure
                 )
                .ToList();

        }

        public Supply GetSupplyById(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.Supply_SelectById";
            var supplyDictionary = new Dictionary<int, Supply>();
            return sqlConnection
                .Query<Supply, SupplyDetail, Supply>(procName,
                (supply, supplyDetail) =>
                {
                    Supply supplyEntry;

                    if (!supplyDictionary.TryGetValue(supply.Id, out supplyEntry))
                    {
                        supplyEntry = supply;
                        supplyEntry.SupplyDetails = new List<SupplyDetail>();
                        supplyDictionary.Add(supplyEntry.Id, supplyEntry);
                    }

                    supplyEntry.SupplyDetails.Add(supplyDetail);
                    return supplyEntry;
                },
                new { Id = id },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure).FirstOrDefault();

        }

        public int AddSupply(Supply supply)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.Supply_Insert";
            return sqlConnection
                .QueryFirstOrDefault<int>(
                    procName,
                    new { Date = supply.Date },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteSupply(int id)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.Supply_Delete";
            sqlConnection
                .Execute(
                    procName,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void EditSupply(Supply supply)
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.Supply_Update";

            sqlConnection
                
                .Execute(
                    procName,
                    new {Id = supply.Id, 
                        Date = supply.Date },
                    commandType: CommandType.StoredProcedure 
                );
        }
    }
}