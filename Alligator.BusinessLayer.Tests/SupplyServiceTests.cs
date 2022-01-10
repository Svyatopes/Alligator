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
    public class SupplyServiceTests
    {
        private readonly Mock<ISupplyRepository> _supplyRepositoryMock;
        


        public SupplyServiceTests()
        {
            _supplyRepositoryMock = new Mock<ISupplyRepository>();
            
        }

        public void FillTestObjectsForGetAllSupplies()
        {
            _supplyRepositoryMock.Setup(m => m.GetSupplies()).Returns(new List<Supply>
            {
                new Supply {
                    Id = 1,
                    Date = DateTime.Now,
                    SupplyDetails = new List<SupplyDetail>()
                },
                new Supply {
                    Id = 2,
                    Date = DateTime.Now,
                    SupplyDetails = new List<SupplyDetail>()
                },
                new Supply {
                    Id = 3,
                    Date = DateTime.Now,
                    SupplyDetails = new List<SupplyDetail>()
                }
            });

        }

        public void FillTestObjectsForGetSupplyById()
        {
            _supplyRepositoryMock.Setup(m => m.GetSupplyById(1)).Returns(new Supply
            {
                Id = 1,
                Date = DateTime.Now,
                SupplyDetails = new List<SupplyDetail>()

            });
            _supplyRepositoryMock.Setup(m => m.GetSupplyById(2)).Returns(new Supply
            {
                Id = 2,
                Date = DateTime.Now,
                SupplyDetails = new List<SupplyDetail>()

            });
            _supplyRepositoryMock.Setup(m => m.GetSupplyById(3)).Returns(new Supply
            {
                Id = 3,
                Date = DateTime.Now,
                SupplyDetails = new List<SupplyDetail>()

            });
        }
        
        public SupplyModel GetTestSuppliesModelToFill(int key)
        {
            SupplyModel result;
            switch (key)
            {
                case 1:
                    result = new SupplyModel
                    {
                        Id = 1,                        
                        Date = DateTime.Now,
                        Details = new List<SupplyDetailModel>() 
                    };
                    break;

                case 2:
                    result = new SupplyModel
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Details = new List<SupplyDetailModel>()
                    };
                    break;
                case 3:
                    result = new SupplyModel
                    {
                        Id = 3,
                        Date = DateTime.Now,
                        Details = new List<SupplyDetailModel>()
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }




        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAllSupplies_ShouldReturnSuppliesShortInfo()
        {
            //arrange            

            var sut = new SupplyService(_supplyRepositoryMock.Object);
            FillTestObjectsForGetAllSupplies();
            //act
            var actual = sut.GetAllSupplies();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Date);
            Assert.IsInstanceOf(typeof(SupplyModel), actual[0]);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetSupplyById_ShouldReturnSupply(int id)
        {
            //arrange            

            var sut = new SupplyService(_supplyRepositoryMock.Object);
            FillTestObjectsForGetSupplyById();

            //act
            var actual = sut.GetSupplyById(id);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Id == id);
            Assert.IsNotNull(actual.Date);
            Assert.IsInstanceOf(typeof(SupplyModel), actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteSupply_ShouldDeleteSupplyById(int id)
        {
            //arrange            

            var sut = new SupplyService(_supplyRepositoryMock.Object);

            //act
            var actual = sut.DeleteSupply(id);

            //assert
            _supplyRepositoryMock.Verify(m => m.DeleteSupply(id), Times.Once());
            Assert.IsTrue(actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void UpdateSupply_ShouldUpdateSupply(int key)
        {
            //arrange            

            var sut = new SupplyService(_supplyRepositoryMock.Object);
            var testSupply = GetTestSuppliesModelToFill(key);

            //act
            var actual = sut.UpdateSupply(testSupply);

            //assert
            Assert.IsTrue(actual);

        }   
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void InsertSupply_ShouldReturnId(int key)
        {
            //arrange            

            var sut = new SupplyService(_supplyRepositoryMock.Object);
            var testSupply = GetTestSuppliesModelToFill(key);

            //act
            var actual = sut.InsertSupply(testSupply);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            
        }        
    }
}