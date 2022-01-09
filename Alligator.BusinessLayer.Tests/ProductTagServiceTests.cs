using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Tests
{
    public class ProductTagServiceTests
    {
        private readonly Mock<IProductTagRepository> _productTagRepositoryMock;

        public ProductTagServiceTests()
        {
            _productTagRepositoryMock = new Mock<IProductTagRepository>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllProductTags_ShouldReturnActionResultWithListProductTags()
        {
            //arrange            
            _productTagRepositoryMock.Setup(m => m.GetProductTags()).Returns(new List<ProductTag>
            {
                new ProductTag()
                {
                    Id = 1,
                    Name = "SomeName"
                }
            });
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.GetAllProductTags();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsTrue(actual.Data.Count == 1);
            Assert.IsInstanceOf(typeof(ProductTagModel), actual.Data[0]);
        }

        [Test]
        public void GetProductTags_ShouldThrownUnsuccessActionResult()
        {
            //arrange
            var errorMessage = "Error with DB";
            _productTagRepositoryMock.Setup(m => m.GetProductTags()).Throws(new System.Exception(errorMessage));
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.GetAllProductTags();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsTrue(actual.Data.Count == 0);
            Assert.AreEqual(errorMessage, actual.ErrorMessage);
        }

        [Test]
        public void AddProductTag_ShouldReturnActionResultWithProductTagModel()
        {
            //arrange

            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.AddProductTag(It.IsAny<string>())).Returns(productTag.Id);
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.AddProductTag(productTag.Name);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsInstanceOf(typeof(ProductTagModel), actual.Data);
            Assert.AreEqual(productTag, actual.Data);
        }


        [Test]
        public void AddProductTag_ShouldReturnUnsuccessActionResult()
        {
            //arrange
            var errorMessage = "Error with DB";
            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.AddProductTag(It.IsAny<string>())).Throws(new System.Exception(errorMessage));
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.AddProductTag(productTag.Name);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsInstanceOf(typeof(ProductTagModel), actual.Data);
            Assert.AreEqual(errorMessage, actual.ErrorMessage);
        }

        [Test]
        public void UpdateProductTag_ShouldReturnBooleanUpdated()
        {
            //arrange

            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.UpdateProductTag(It.IsAny<ProductTag>())).Returns(true);
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.UpdateProductTag(productTag);

            //assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void UpdateProductTag_ShouldReturnBooleanNotUpdatedWhenErrorInRepository()
        {
            //arrange

            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.UpdateProductTag(It.IsAny<ProductTag>())).Throws(new System.Exception());
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.UpdateProductTag(productTag);

            //assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void DeleteProductTag_ShouldReturnBooleanDeleted()
        {
            //arrange

            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.DeleteProductTag(It.IsAny<ProductTag>())).Returns(true);
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.DeleteProductTag(productTag);

            //assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void DeleteCategory_ShouldReturnBooleanNotDeletedWhenErrorInRepository()
        {
            //arrange

            var productTag = new ProductTagModel() { Id = 5, Name = "PrOdUCt TaG" };
            _productTagRepositoryMock.Setup(m => m.DeleteProductTag(It.IsAny<ProductTag>())).Throws(new System.Exception());
            var productTagService = new ProductTagService(_productTagRepositoryMock.Object);

            //act
            var actual = productTagService.DeleteProductTag(productTag);

            //assert
            Assert.IsFalse(actual);
        }
    }
}