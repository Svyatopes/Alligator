using Alligator.DataLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Repositories
{
    class RepositoryProduct
    {
        private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";

        public Product GetProductById(int id)
        {
            string procString = "dbo.Product_SelectById";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection
                .Query<Product, Category, Product>(procString, (product, category) => { product.Category = category; return product; },
                new { Id = id }, commandType: CommandType.StoredProcedure, splitOn: "Id")
                .FirstOrDefault();
        }

        public List<Product> GetAllProducts()
        {
            string procString = "dbo.Product_SelectAll";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            
            return connection
                .Query<Product, Category, Product>(procString, (product, category) => {product.Category = category; return product; }, 
                commandType: CommandType.StoredProcedure,splitOn: "Id")
                .Distinct()
                .ToList();            
        }

        public void AddProduct(string name, Category category)
        {
            string procString = "dbo.Product_Insert";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query(procString, new { Name = name, CategoryId = category.Id }, commandType: CommandType.StoredProcedure);
        }

        public void EditProduct(int id, string name, Category category)
        {
            string procString = "dbo.Product_Update";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query<Product>(procString, new { Id = id, Name = name, CategoryId = category.Id }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            string procString = "dbo.Category_Delete";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query<Product>(procString, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
