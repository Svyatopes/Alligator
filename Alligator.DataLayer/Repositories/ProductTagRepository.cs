using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class ProductTagRepository : BaseRepository
    {

        public ProductTag GetProductTagById(int id)
        {
            string procString = "dbo.ProductTag_SelectById";
            using var connection = ProvideConnection();

            var productTag = connection.QueryFirstOrDefault<ProductTag>(procString, new { Id = id }, commandType: CommandType.StoredProcedure);

            return productTag;

        }

        public List<ProductTag> GetProductTags()
        {
            string procString = "dbo.ProductTag_SelectAll";
            using var connection = ProvideConnection();

            var productTags = connection.Query<ProductTag>(procString).ToList();

            return productTags;

        }

        public int AddProductTag(string name)
        {
            string procString = "dbo.ProductTag_Insert";
            using var connection = ProvideConnection();

            return connection.QuerySingle<int>(procString, new { Name = name }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Update";
            using var connection = ProvideConnection();

            connection.Execute(procString, new { productTag.Id, productTag.Name }, commandType: CommandType.StoredProcedure);

        }


        public bool DeleteProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Delete";
            using var connection = ProvideConnection();

            return connection.Execute(procString, new { productTag.Id }, commandType: CommandType.StoredProcedure) == 1;

        }
    }
}
