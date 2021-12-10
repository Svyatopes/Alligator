using Alligator.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var command = new SqlCommand(procString, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            var productTag = new ProductTag();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                   productTag.Id = reader.GetInt32(reader.GetOrdinal(nameof(ProductTag.Id)));
                   productTag.Name = reader.GetString(reader.GetOrdinal(nameof(ProductTag.Name)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return productTag;

        }

        public List<ProductTag> GetProductTags()
        {
            string procString = "dbo.ProductTag_SelectAll";


            using var connection = new SqlConnection(_connectionString);

            var command = new SqlCommand(procString, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            var productTags = new List<ProductTag>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productTags.Add(new ProductTag()
                    {

                        Id = reader.GetInt32(reader.GetOrdinal(nameof(ProductTag.Id))),
                        Name = reader.GetString(reader.GetOrdinal(nameof(ProductTag.Name)))
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return productTags;

        }

        public void AddProductTag(string name)
        {
            string procString = "dbo.ProductTag_Insert";

            using var connection = new SqlConnection(_connectionString);

            var command = new SqlCommand(procString, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);

            try
            {
                connection.Open();
                var number = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void EditProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Update";


            using var connection = new SqlConnection(_connectionString);

            var command = new SqlCommand(procString, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", productTag.Id);
            command.Parameters.AddWithValue("@Name", productTag.Name);

            try
            {
                connection.Open();
                var number = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }


        public void DeleteProductTag(ProductTag productTag)
        {
            string procString = "dbo.ProductTag_Delete";


            using var connection = new SqlConnection(_connectionString);

            var command = new SqlCommand(procString, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", productTag.Id);

            try
            {
                connection.Open();
                var number = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }



    }
}
