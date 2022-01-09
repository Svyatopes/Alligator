using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface ICategoryRepository
    {
        bool DeleteCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int InsertCategory(string name);
        bool UpdateCategory(Category category);
    }
}