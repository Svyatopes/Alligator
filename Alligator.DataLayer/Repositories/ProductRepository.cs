using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        //private const string _connectionString = "Data Source=(local);Database=AggregatorAlligator;Integrated Security=true";

        public Product GetProductById(int id)
        {
            string procString = "dbo.Product_SelectById";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection
                .Query<Product, Category, Product>(procString, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure, splitOn: "Id")
                .FirstOrDefault();

        }

        public List<Product> GetAllProducts()
        {
            string procString = "dbo.Product_SelectAll";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection
                //.Query<Product, Category, Product>(procString, (product, category) =>
                //{
                //    //product.Category
                //    product.Category = category;
                //    return product;
                //},
                //commandType: CommandType.StoredProcedure, splitOn: "Id")
                //.Distinct()
                //.ToList();

                .Query<Product>(procString
                , commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public void AddProduct(Product product)
        {
            string procString = "dbo.Product_Insert";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Execute(procString, new
            {
                Name = product.Name,
                CategoryId = product.Category.Id
            },
                commandType: CommandType.StoredProcedure);
        }

        public void EditProduct(Product product)
        {
            string procString = "dbo.Product_Update";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Execute(procString, new
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.Category.Id
            },
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            string procString = "dbo.Category_Delete";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Execute(procString, new
            {
                Id = id
            },
                commandType: CommandType.StoredProcedure);
        }
    }
}
