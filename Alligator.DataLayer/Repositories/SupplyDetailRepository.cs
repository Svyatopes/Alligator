using System.Collections.Generic;
using Alligator.DataLayer.Entities;
using System.Linq;
using Dapper;
using System.Data;

namespace Alligator.DataLayer.Repositories
{
    public class SupplyDetailRepository : BaseRepository, ISupplyDetailRepository
    {

        public List<SupplyDetail> GetAllSupplyDetails()
        {
            using var sqlConnection = ProvideConnection();

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
            using var connection = ProvideConnection();

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
            using var connection = ProvideConnection();

            string procName = "dbo.SupplyDetail_Insert";

            return connection
                .QueryFirstOrDefault<int>(
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
            using var connection = ProvideConnection();

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
            using var connection = ProvideConnection();

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
            using var connection = ProvideConnection();

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