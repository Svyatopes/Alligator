using System.Collections.Generic;
using Alligator.DataLayer.Entities;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Alligator.DataLayer.Repositories
{
    public class SupplyDetailRepository : ISupplyDetailRepository
    {

        private const string _connString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

        public List<SupplyDetail> GetAllSupplyDetails()
        {
            using var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();

            string procName = "dbo.SupplyDetail_SelectAll";
            return sqlConnection
                .Query<SupplyDetail, Product, Category, SupplyDetail>(
                    procName,
                    (supplyDetail, product, category) =>
                    {
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

        public List<SupplyDetail> GetSupplyDetailBySupplyId(int id)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string procName = "dbo.SupplyDetail_SelectBySupplyId";
            var supplyDictionary = new Dictionary<int, SupplyDetail>();
            return connection
                 .Query<SupplyDetail, Product, SupplyDetail>(
                    procName,
                (supplyDetail, product) =>
                {
                    supplyDetail.Product = product;
                    return supplyDetail;
                },
                    new { SupplyId = id },
                    commandType: CommandType.StoredProcedure

               ).ToList();
        }

        public int AddSupplyDetail(SupplyDetail supplyDetail)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string procName = "dbo.SupplyDetail_Insert";

            return connection
                .Execute(
                    procName,
                    new
                    {
                        supplyDetail.Amount,
                        supplyDetail.SupplyId,
                        ProductId = supplyDetail.Product.Id

                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void EditSupplyDetail(List<SupplyDetail> supplyDetail)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string procName = "dbo.SupplyDetail_Update";
            connection
                .Execute(
                    procName,
                    new { Id = supplyDetail, Amount = supplyDetail },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteSupplyDetailBySupplyId(int id)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string procName = "dbo.SupplyDetail_DeleteBySupplyId";
            connection
                .Execute(
                    procName,
                    new { SupplyId = id },
                    commandType: CommandType.StoredProcedure
                );
        }
        public void DeleteSupplyDetailById(int id)
        {
            using var connection = new SqlConnection(_connString);
            connection.Open();

            string procName = "dbo.SupplyDetail_DeleteById";
            connection
                .Execute(
                    procName,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                );
        }
    }
}