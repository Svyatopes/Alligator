using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using System;
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

        public ActionResult<List<CategoryModel>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            try
            {
                return new ActionResult<List<CategoryModel>>(true, CustomMapper.GetInstance().Map<List<CategoryModel>>(categories));

            }
            catch (Exception ex)
            {
                return new ActionResult<List<CategoryModel>>(false, new List<CategoryModel>()) { ErrorMessage = ex.Message };
            }
        }

        public ActionResult<CategoryModel> AddCategory(string name)
        {
            CategoryModel categoryModel = new CategoryModel();
            try
            {
                var id = _categoryRepository.InsertCategory(name);
                categoryModel = new CategoryModel() { Id = id, Name = name };
            }
            catch (Exception ex)
            {
                return new ActionResult<CategoryModel>(false, categoryModel) { ErrorMessage = ex.Message };
            }

            return new ActionResult<CategoryModel>(true, categoryModel);
        }

        public bool UpdateCategory(CategoryModel category)
        {
            var categoryInRepo = CustomMapper.GetInstance().Map<Category>(category);
            try
            {
                return _categoryRepository.UpdateCategory(categoryInRepo);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(CategoryModel category)
        {
            var categoryInRepo = CustomMapper.GetInstance().Map<Category>(category);
            try
            {
                return _categoryRepository.DeleteCategory(categoryInRepo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
