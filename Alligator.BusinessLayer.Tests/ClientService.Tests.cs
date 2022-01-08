using Alligator.BusinessLayer.Services;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Tests
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        
        public ClientServiceTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllClients_ShouldReturnAllClients()
        {
            //arrange
            _clientRepositoryMock.Setup(m => m.GetAllClients()).Returns(new List<Client>
            {
                new Client{
                    Id=1,
                    FirstName = "qwer",
                    LastName = "asdf",
                    Patronymic = "zxc",
                    PhoneNumber = "2356",
                    Email = "qwer@erty"
                }
            });
            var sut = new ClientService(_clientRepositoryMock.Object);
            //act
            var actual = sut.GetAllClients().Data;
            //assert
            _clientRepositoryMock.Verify(m => m.GetAllClients(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
   
            
        }
        [Test]
        public void InsertNewClient()
        {
            //arrange 
            var client = new ClientModel()
            {
                Id = 1,
                FirstName = "qwer",
                LastName = "asdf",
                Patronymic = "zxc",
                PhoneNumber = "2356",
                Email = "qwer@erty"
            };
            _clientRepositoryMock.Setup(m => m.InsertClient(It.IsAny<Client>())).Returns(1);
            var sut = new ClientService(_clientRepositoryMock.Object);
            //act 
            var actual = sut.InsertNewClient(client);
            //assert
            _clientRepositoryMock.Verify(m => m.InsertClient(It.IsAny<Client>()), Times.Once);
        }
        [Test]
        public void DeleteClient()
        {
            //arrange 
            var client = new ClientModel()
            {
                Id = 1,
                FirstName = "qwer",
                LastName = "asdf",
                Patronymic = "zxc",
                PhoneNumber = "2356",
                Email = "qwer@erty"
            };
            _clientRepositoryMock.Setup(m => m.InsertClient(It.IsAny<Client>())).Returns(1);
            var sut = new ClientService(_clientRepositoryMock.Object);
            //act 
            var actual = sut.DeleteClient(client);
            //_clientRepositoryMock.Verify(m=>m.DeleteClient(It.IsAny<Client>))
        }
    }
}