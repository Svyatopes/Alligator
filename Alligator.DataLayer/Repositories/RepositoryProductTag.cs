using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class RepositoryProductTag
    {
        private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        //private const string _connectionString = "Server=(local)\\DEVSERV;Database=AggregatorAlligator;Integrated Security=true;";

        public ProductTag GetProductTagById(int id)
        {
            string procString = "dbo.ProductTag_SelectById";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var productTag = connection.QueryFirstOrDefault<ProductTag>(procString, new { Id = id }, commandType: CommandType.StoredProcedure);

            return productTag;

        }

        public List<ProductTag> GetProductTags()
        {
            string procString = "dbo.ProductTag_SelectAll";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var productTags = connection.Query<ProductTag>(procString).ToList();

            return productTags;

        }

        public void AddProductTag(string name)
        {
            string procString = "dbo.ProductTag_Insert";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            connection.Execute(procString, new { Name = name }, commandType: CommandType.StoredProcedure);
        }

        public void EditProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Update";


            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            connection.Execute(procString, new { productTag.Id, productTag.Name }, commandType: CommandType.StoredProcedure);

        }


        public void DeleteProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Delete";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            connection.Execute(procString, new { productTag.Id }, commandType: CommandType.StoredProcedure);

        }



    }
}
