using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{

    public class CategoryService
    {

        private readonly CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            return CustomMapper.GetInstance().Map<List<CategoryModel>>(categories);
        }

        public CategoryModel AddCategory(string name)
        {
            CategoryModel categoryModel;
            try
            {
                var id = _categoryRepository.InsertCategory(name);
                categoryModel = new CategoryModel() { Id = id, Name = name };
            }
            catch
            {
                return null;
            }

            return categoryModel;
        }

        public bool DeleteCategory(CategoryModel category)
        {
            var categoryInRepo = CustomMapper.GetInstance().Map<Category>(category);
            try
            {
                return _categoryRepository.DeleteCategory(categoryInRepo);
            }
            catch
            {
                return false;
            }
        }
    }
}
