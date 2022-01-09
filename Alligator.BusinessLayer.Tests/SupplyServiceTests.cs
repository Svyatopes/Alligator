using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer.Entities;
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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllSupplies_ShouldReturnSuppliesShortInfo()
        {
            //arrange            
            _supplyRepositoryMock.Setup(m => m.GetSupplies()).Returns(new List<Supply>
            {
                new Supply {
                    Id = 1,
                    Date = System.DateTime.Now,
                    SupplyDetails = new List<SupplyDetail>()
                }
            });
            var sut = new SupplyService(_supplyRepositoryMock.Object);

            //act
            var actual = sut.GetAllSupplies();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Date);
            Assert.IsInstanceOf(typeof(SupplyModel), actual[0]);
            
        }
    }
}