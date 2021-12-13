﻿using Alligator.DataLayer.Entities;
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
    class RepositoryCategory
    {
        private const string _connectionString = "Data Source=80.78.240.16;Database=AggregatorAlligator;User Id=student;Password=qwe!23;";
        
        public Category GetCategoryById(int id)
        {
            string procString = "dbo.Category_SelectById";
            using var connection = new SqlConnection(_connectionString);           

            connection.Open();           

            var category = connection.QueryFirstOrDefault<Category>(procString, new { Id = id }, commandType: CommandType.StoredProcedure);

            return category;
        }

        public List<Category> GetAllCategories()
        {
            string procString = "dbo.Category_SelectAll";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            var categories = connection.Query<Category>(procString).ToList();

            return categories;
        }

        public void InsertCategory(string name)
        {
            string procString = "dbo.Category_Insert";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query<Category>(procString, new { Name = name }, commandType: CommandType.StoredProcedure);            
        }

        public void UpdateCategory(Category category)
        {
            string procString = "dbo.Category_Update";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query<Category>(procString, new { category.Id, category.Name }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(Category category)
        {
            string procString = "dbo.Category_Delete";
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            connection.Query<Category>(procString, new { category.Id }, commandType: CommandType.StoredProcedure);
        }

    }
}
