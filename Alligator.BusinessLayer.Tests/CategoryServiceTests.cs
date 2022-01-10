using Alligator.BusinessLayer.Models;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllCategories_ShouldReturnActionResultWithCategories()
        {
            //arrange            
            _categoryRepositoryMock.Setup(m => m.GetAllCategories()).Returns(new List<Category>
            {
                new Category()
                {
                    Id = 1,
                    Name = "SomeName"
                }
            });
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.GetAllCategories();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsTrue(actual.Data.Count == 1);
            Assert.IsInstanceOf(typeof(CategoryModel), actual.Data[0]);
        }

        [Test]
        public void GetAllCategories_ShouldThrownUnsuccessActionResult()
        {
            //arrange
            var errorMessage = "Error with DB";
            _categoryRepositoryMock.Setup(m => m.GetAllCategories()).Throws(new System.Exception(errorMessage));
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.GetAllCategories();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Success);
            Assert.IsNull(actual.Data);
            Assert.AreEqual(errorMessage, actual.ErrorMessage);
        }

        [Test]
        public void AddCategory_ShouldReturnActionResultWithCategoryModel()
        {
            //arrange

            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.InsertCategory(It.IsAny<string>())).Returns(category.Id);
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.AddCategory(category.Name);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsInstanceOf(typeof(CategoryModel), actual.Data);
            Assert.AreEqual(category, actual.Data);
        }


        [Test]
        public void AddCategory_ShouldReturnUnsuccessActionResult()
        {
            //arrange
            var errorMessage = "Error with DB";
            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.InsertCategory(It.IsAny<string>())).Throws(new System.Exception(errorMessage));
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.AddCategory(category.Name);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Success);
            Assert.IsNull(actual.Data);
            Assert.AreEqual(errorMessage, actual.ErrorMessage);
        }

        [Test]
        public void UpdateCategory_ShouldReturnBooleanUpdated()
        {
            //arrange

            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.UpdateCategory(It.IsAny<Category>())).Returns(true);
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.UpdateCategory(category);

            //assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void UpdateCategory_ShouldReturnBooleanNotUpdatedWhenErrorInRepository()
        {
            //arrange

            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.UpdateCategory(It.IsAny<Category>())).Throws(new System.Exception());
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.UpdateCategory(category);

            //assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void DeleteCategory_ShouldReturnBooleanDeleted()
        {
            //arrange

            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.DeleteCategory(It.IsAny<Category>())).Returns(true);
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.DeleteCategory(category);

            //assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void DeleteCategory_ShouldReturnBooleanNotDeletedWhenErrorInRepository()
        {
            //arrange

            var category = new CategoryModel() { Id = 5, Name = "CaTeGoRy" };
            _categoryRepositoryMock.Setup(m => m.DeleteCategory(It.IsAny<Category>())).Throws(new System.Exception());
            var categoryService = new CategoryService(_categoryRepositoryMock.Object);

            //act
            var actual = categoryService.DeleteCategory(category);

            //assert
            Assert.IsFalse(actual);
        }
    }
}