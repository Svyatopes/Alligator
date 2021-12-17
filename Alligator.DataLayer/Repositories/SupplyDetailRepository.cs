using System.Collections.Generic;
using Alligator.DataLayer.Entities;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Alligator.DataLayer.Repositories
{
    public class SupplyDetailRepository
    {

        private const string _connString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        //string _connString = "Server=(local);Database=AggregatorAlligator;Integrated Security=true";

        public List<SupplyDetail> GetAllSupplyDetails() //сходили в бд
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string dbo = "dbo.SupplyDetail_SelectAll";
            return sqlConnection
                .Query<SupplyDetail, Supply, Product, Category, SupplyDetail>(
                    dbo,
                    (supplyDetail, supply, product, category) =>
                    {
                        supplyDetail.Supply = supply;
                        supplyDetail.Product = product;
                        product.Category = category;

                        return supplyDetail;
                    },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .Distinct()
                .ToList();
        }

        public List<SupplyDetail> GetSupplyDetailById(int id)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string dbo = "dbo.SupplyDetail_SelectById";
            return connection
                .Query<SupplyDetail, Supply, Product, Category, SupplyDetail>(
                    dbo,
                    (supplyDetail, supply, product, category) =>
                    {
                        supplyDetail.Supply = supply;
                        supplyDetail.Product = product;
                        product.Category = category;

                        return supplyDetail;
                    },
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .ToList();
        }

        public void AddSupplyDetail(int amount, int supplyId, int productId)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string dbo = "dbo.SupplyDetail_Insert";
            connection
                .Execute(
                    dbo,
                    new { Amount = amount, SupplyId = supplyId, ProductId = productId },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void EditSupplyDetail(int id, int amount)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string dbo = "dbo.SupplyDetail_Update";
            connection
                .Execute(
                    dbo,
                    new { Id = id, Amount = amount },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteSupplyDetail(int id)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string dbo = "dbo.SupplyDetail_Delete";
            connection
                .Execute(
                    dbo,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                );
        }
    }
}