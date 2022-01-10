using Alligator.BusinessLayer.Models;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetProductById_ShouldReturnActionResultWithProduct()
        {
            //arrange            
            _productRepositoryMock.Setup(m => m.GetProductById(It.IsAny<int>())).Returns(new Product
            {
                Id = 1,
                Name = "Product Name",
                Category = new Category()
                {
                    Id = 1,
                    Name = "Category Name"
                },
                ProductTags = new List<ProductTag>()
               {
                   new ProductTag()
                   {
                       Id=1,
                       Name="ProductTag Name"
                   }
               }
            });

            var productService = new ProductService(_productRepositoryMock.Object);

            //act
            var actual = productService.GetProductById(2);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
            Assert.IsInstanceOf(typeof(ProductModel), actual.Data);
            Assert.IsNotNull(actual.Data.Category);
            Assert.IsNotNull(actual.Data.ProductTags);
            Assert.IsTrue(actual.Data.ProductTags.Count == 1);
        }

    }
}