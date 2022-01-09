using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public Product GetProductById(int id)
        {
            string procString = "dbo.Product_SelectById";
            using var connection = ProvideConnection();

            var productDictionary = new Dictionary<int, Product>();

            return connection
                .Query<Product, Category, ProductTag, Product>(procString, (product, category, productTag) =>
                {
                    Product productEntry;
                    if (!productDictionary.TryGetValue(product.Id, out productEntry))
                    {
                        productEntry = product;
                        productEntry.ProductTags = new List<ProductTag>();
                        productEntry.Category = category;
                        productDictionary.Add(product.Id, productEntry);
                    }

                    if (productTag != null)
                        productEntry.ProductTags.Add(productTag);
                    return productEntry;
                },
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id")
                .FirstOrDefault();

        }

        public List<Product> GetAllProducts()
        {
            string procString = "dbo.Product_SelectAll";
            using var connection = ProvideConnection();

            return connection
                .Query<Product, Category, Product>(procString, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id")

                .ToList();


        }

        public int AddProduct(Product product)
        {
            string procString = "dbo.Product_Insert";
            using var connection = ProvideConnection();


            return connection.QueryFirstOrDefault<int>(procString,
                new
                {
                    Name = product.Name,
                    CategoryId = product.Category.Id
                },
            commandType: CommandType.StoredProcedure);
        }

        public bool EditProduct(Product product)
        {
            string procString = "dbo.Product_Update";
            using var connection = ProvideConnection();

            return connection.Execute(procString,
                new
                {
                    product.Id,
                    product.Name,
                    CategoryId = product.Category.Id
                },
                commandType: CommandType.StoredProcedure)
                == (int)AffectedRows.One;
        }

        public bool DeleteProduct(int id)
        {
            string procString = "dbo.Product_Delete";
            using var connection = ProvideConnection();

            return connection.Execute(procString,
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure)
                == (int)AffectedRows.One;
        }
    }
}
