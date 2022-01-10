using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Tests
{
    public class SupplyDetailServiceTests
    {
        private readonly Mock<ISupplyDetailRepository> _supplyDetailRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;


        public SupplyDetailServiceTests()
        {
            _supplyDetailRepositoryMock = new Mock<ISupplyDetailRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        public void FillTestObjectsForGetAllSupplyDetails()
        {
            _supplyDetailRepositoryMock.Setup(m => m.GetAllSupplyDetails()).Returns(new List<SupplyDetail>
            {
                new SupplyDetail {
                   Id = 1,
                   Amount = 1,
                   SupplyId = 1,
                   Product = new Product()
                   {
                       Id = 1,
                       Name = "g",
                       Category = new Category ()
                       {
                           Id = 1,
                           Name = "g"
                       }
                   }
                },
                new SupplyDetail {
                   Id = 2,
                   Amount = 2,
                   SupplyId = 2,
                   Product = new Product()
                   {
                       Id = 2,
                       Name = "k",
                       Category = new Category ()
                       {
                           Id = 2,
                           Name = "k"
                       }
                   }
                },new SupplyDetail {
                   Id = 3,
                   Amount = 3,
                   SupplyId = 3,
                   Product = new Product()
                   {
                       Id = 3,
                       Name = "h",
                       Category = new Category ()
                       {
                           Id = 3,
                           Name = "h"
                       }
                   }
                }
            });

        }


        public void FillTestObjectsForGetSupplyDetailBySupplyId()
        {
            _supplyDetailRepositoryMock.Setup(m => m.GetSupplyDetailBySupplyId(1)).Returns(new List<SupplyDetail>
            {
                new SupplyDetail
                {
                   Id = 1,
                   Amount = 1,
                   SupplyId = 1,
                   Product = new Product()
                   {
                       Id = 1,
                       Name = "g",
                       Category = new Category ()
                       {
                           Id = 1,
                           Name = "g"
                       }
                   }
                },
                new SupplyDetail
                {
                   Id = 2,
                   Amount = 2,
                   SupplyId = 1,
                   Product = new Product()
                   {
                       Id = 2,
                       Name = "q",
                       Category = new Category ()
                       {
                           Id = 2,
                           Name = "q"
                       }
                   }
                },
                new SupplyDetail
                {
                   Id = 3,
                   Amount = 3,
                   SupplyId = 1,
                   Product = new Product()
                   {
                       Id = 3,
                       Name = "a",
                       Category = new Category ()
                       {
                           Id = 3,
                           Name = "a"
                       }
                   }
                }
            });

            _supplyDetailRepositoryMock.Setup(m => m.GetSupplyDetailBySupplyId(2)).Returns(new List<SupplyDetail>
            {
                new SupplyDetail
                {
                   Id = 1,
                   Amount = 1,
                   SupplyId = 2,
                   Product = new Product()
                   {
                       Id = 1,
                       Name = "g",
                       Category = new Category ()
                       {
                           Id = 1,
                           Name = "g"
                       }
                   }
                },
                new SupplyDetail
                {
                   Id = 2,
                   Amount = 2,
                   SupplyId = 2,
                   Product = new Product()
                   {
                       Id = 2,
                       Name = "q",
                       Category = new Category ()
                       {
                           Id = 2,
                           Name = "q"
                       }
                   }
                },
                new SupplyDetail
                {
                   Id = 3,
                   Amount = 3,
                   SupplyId = 2,
                   Product = new Product()
                   {
                       Id = 3,
                       Name = "a",
                       Category = new Category ()
                       {
                           Id = 3,
                           Name = "a"
                       }
                   }
                }
            });
        }
        
        public void FillTestObjectsForGetProductById()
        {
            _productRepositoryMock.Setup(m => m.GetProductById(1)).Returns(new Product
            {
                Id = 1,
                Name = "f",
                Category = new Category()
                {
                    Id = 1,
                    Name = "f"
                }
            });

            _productRepositoryMock.Setup(m => m.GetProductById(2)).Returns(new Product
            {
                Id = 2,
                Name = "k",
                Category = new Category()
                {
                    Id = 2,
                    Name = "k"
                }
            }); 
            _productRepositoryMock.Setup(m => m.GetProductById(3)).Returns(new Product
            {
                Id = 3,
                Name = "l",
                Category = new Category()
                {
                    Id = 3,
                    Name = "l"
                }
            });
        }
        public List<SupplyDetailModel> GetTestListSupplyDetailsModelToFill(int key)
        {
            List<SupplyDetailModel> result;
            switch (key)
            {
                case 1:
                    result = new List<SupplyDetailModel>
                    {
                        new SupplyDetailModel{
                            Id = 1,
                            Amount = 1,
                            SupplyId = 1,
                            Product = new ProductModel()
                            {
                                Id = 1,
                                Name = "a",
                                Category = new CategoryModel()
                                {
                                    Id = 1,
                                    Name = "a"
                                }
                            }
                        },
                        new SupplyDetailModel{
                            Id = 11,
                            Amount = 11,
                            SupplyId = 1,
                            Product = new ProductModel()
                            {
                                Id = 11,
                                Name = "aaaa",
                                Category = new CategoryModel()
                                {
                                    Id = 11,
                                    Name = "aaaa"
                                }
                            }
                        }

                    };
                    break;

                case 2:
                    result = new List<SupplyDetailModel>
                    {
                        new SupplyDetailModel{
                            Id = 2,
                            Amount = 2,
                            SupplyId = 2,
                            Product = new ProductModel()
                            {
                                Id = 2,
                                Name = "b",
                                Category = new CategoryModel()
                                {
                                    Id = 2,
                                    Name = "b"
                                }
                            }
                        },
                        new SupplyDetailModel{
                            Id = 22,
                            Amount = 22,
                            SupplyId = 2,
                            Product = new ProductModel()
                            {
                                Id = 22,
                                Name = "bbbbb",
                                Category = new CategoryModel()
                                {
                                    Id = 22,
                                    Name = "bbbb"
                                }
                            }
                        }

                    };
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }
        public SupplyDetailModel GetTestSupplyDetailsModelToFill(int key)
        {
            SupplyDetailModel result;
            switch (key)
            {
                case 1:
                    result = new SupplyDetailModel
                    {
                        Id = 1,
                        Amount = 1,
                        SupplyId = 1,
                        Product = new ProductModel()
                        {
                            Id = 1,
                            Name = "a",
                            Category = new CategoryModel()
                            {
                                Id = 1,
                                Name = "a"
                            }
                        }
                    };
                    break;

                case 2:
                    result = new SupplyDetailModel
                    {
                        Id = 2,
                        Amount = 2,
                        SupplyId = 2,
                        Product = new ProductModel()
                        {
                            Id = 2,
                            Name = "b",
                            Category = new CategoryModel()
                            {
                                Id = 2,
                                Name = "b"
                            }
                        }
                    };
                    break;
                case 3:
                    result = new SupplyDetailModel
                    {
                        Id = 3,
                        Amount = 3,
                        SupplyId = 3,
                        Product = new ProductModel()
                        {
                            Id = 3,
                            Name = "c",
                            Category = new CategoryModel()
                            {
                                Id = 3,
                                Name = "c"
                            }
                        }
                    };
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }


        public void FillTestObjectsForGetProducts()
        {
            _productRepositoryMock.Setup(m => m.GetAllProducts()).Returns(new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "g",
                    Category = new Category ()
                    {
                        Id = 1,
                        Name = "g"
                    }

                },
                new Product()
                {
                    Id = 2,
                    Name = "k",
                    Category = new Category()
                    {
                        Id = 2,
                        Name = "k"
                    }
                },

                new Product()
                {
                    Id = 3,
                    Name = "h",
                    Category = new Category()
                    {
                        Id = 3,
                        Name = "h"
                    }
                }
            });
        }



        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAllSupplyDetails_ShouldReturnAllSupplyDetails()
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            FillTestObjectsForGetAllSupplyDetails();
            //act
            var actual = sut.GetAllSupplyDetails();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Product);
            Assert.IsInstanceOf(typeof(SupplyDetailModel), actual[0]);

        }



        [TestCase(1)]
        [TestCase(2)]

        public void GetSupplyDetailBySupplyId_ShouldReturnListSupplyDetailsById(int id)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            FillTestObjectsForGetSupplyDetailBySupplyId();

            //act
            var actual = sut.GetSupplyDetailBySupplyId(id);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual[0].SupplyId == id);
            Assert.IsNotNull(actual[0].Product);
            Assert.IsInstanceOf(typeof(List<SupplyDetailModel>), actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteSupplyDetailById_ShouldDeleteSupplyDetailById(int id)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);

            //act
            var actual = sut.DeleteSupplyDetailById(id);

            //assert
            _supplyDetailRepositoryMock.Verify(m => m.DeleteSupplyDetailById(id), Times.Once());
            Assert.IsTrue(actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteSupplyDetailBySupplyId_ShouldDeleteSupplyDetailBySupplyId(int supplyId)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);

            //act
            var actual = sut.DeleteSupplyDetailBySupplyId(supplyId);

            //assert
            _supplyDetailRepositoryMock.Verify(m => m.DeleteSupplyDetailBySupplyId(supplyId), Times.Once());
            Assert.IsTrue(actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        public void UpdateSupplyDetail_ShouldUpdateSupplyDetail(int key)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            var testSupply = GetTestListSupplyDetailsModelToFill(key);

            //act
            var actual = sut.UpdateSupplyDetail(testSupply);

            //assert
            Assert.IsTrue(actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void InsertSupply_ShouldReturnId(int key)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            var testSupply = GetTestSupplyDetailsModelToFill(key);

            //act
            var actual = sut.InsertSupplyDetail(testSupply);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);

        }


        [Test]
        public void GetProducts_ShouldReturnAllProducts()
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            FillTestObjectsForGetProducts();
            //act
            var actual = sut.GetProducts();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Category);
            Assert.IsInstanceOf(typeof(ProductModel), actual[0]);

        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public void GetProductById_ShouldReturnProduct(int id)
        {
            //arrange            

            var sut = new SupplyDetailService(_supplyDetailRepositoryMock.Object, _productRepositoryMock.Object);
            FillTestObjectsForGetProductById();

            //act
            var actual = sut.GetProductById(id);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Id == id);
            Assert.IsNotNull(actual.Category);
            Assert.IsInstanceOf(typeof(ProductModel), actual);

        }
    }
}