using Alligator.DataLayer.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Alligator.DataLayer.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public Category GetCategoryById(int id)
        {
            string procString = "dbo.Category_SelectById";
            using var connection = ProvideConnection();

            var category = connection.QueryFirstOrDefault<Category>
                (procString, new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure);

            return category;
        }

        public List<Category> GetAllCategories()
        {
            string procString = "dbo.Category_SelectAll";
            using var connection = ProvideConnection();

            var categories = connection.Query<Category>(procString).ToList();

            return categories;
        }

        public int InsertCategory(string name)
        {
            string procString = "dbo.Category_Insert";

            using var connection = ProvideConnection();

            return connection.QueryFirstOrDefault<int>(procString, new
            {
                Name = name
            },
                commandType: CommandType.StoredProcedure);
        }

        public bool UpdateCategory(Category category)
        {
            string procString = "dbo.Category_Update";
            using var connection = ProvideConnection();

            return connection.Execute(procString, 
                new
                {
                    category.Id,
                    category.Name
                },
                commandType: CommandType.StoredProcedure)
                == (int)AffectedRows.One;
        }

        public bool DeleteCategory(Category category)
        {
            string procString = "dbo.Category_Delete";
            using var connection = ProvideConnection();

            return connection.Execute(procString, new { category.Id }, commandType: CommandType.StoredProcedure) == (int)AffectedRows.One;
        }
    }
}
