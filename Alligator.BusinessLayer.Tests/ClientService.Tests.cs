using Alligator.BusinessLayer.Services;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer;
using System.Collections.Generic;
using Alligator.DataLayer.Entities;

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

        public void FillRepositoryMockGetAllClients()
        {
            _clientRepositoryMock.Setup(m => m.GetAllClients()).Returns(new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "TestFirstName1",
                    LastName = "TestLastName1",
                    Patronymic = "TestPatronymic1",
                    PhoneNumber = "1234567",
                    Email = "TestEmail1"

                },
                new Client
                    {
                    Id = 2,
                    FirstName = "TestFirstName2",
                    LastName = "TestLastName2",
                    Patronymic = "TestPatronymic2",
                    PhoneNumber = "1234567",
                    Email = "TestEmail2"
                }
            });
        }

        

        public ClientModel GetClientModelToFillRepositoryMock(int key)
        {
            ClientModel client;
            switch (key)
            {
                case 1:
                    client = new ClientModel
                    {
                        Id = 1,
                        FirstName = "TestFirstName1",
                        LastName = "TestLastName1",
                        Patronymic = "TestPatronymic1",
                        PhoneNumber = "TestPhoneNumber1",
                        Email = "TestEmail1"
                    };
                    break;
                case 2:
                    client = new ClientModel
                    {
                        Id = 2,
                        FirstName = "TestFirstName2",
                        LastName = "TestLastName2",
                        Patronymic = "TestPatronymic2",
                        PhoneNumber = "TestPhoneNumber2",
                        Email = "TestEmail2"
                    };
                    break;
                default:
                    client = null;
                    break;
            }
            return client;
        }


        [Test]
        public void GetAllClients_ShouldReturnAllClients()
        {
            //arrange

            var sut = new ClientService(_clientRepositoryMock.Object);
            FillRepositoryMockGetAllClients();
            //act
            var actual = sut.GetAllClients().Data;
            //assert
            _clientRepositoryMock.Verify(m => m.GetAllClients(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(ClientModel), actual[0]);


        }



        [TestCase(1)]

        public void GetClientById_ShouldReturnClient(int id)
        {
            var sut = new ClientService(_clientRepositoryMock.Object);
            var actual = sut.GetClientById(id);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            Assert.IsNotNull(actual.Data);
           
        }
        [TestCase(1)]
        [TestCase(2)]

        public void InsertNewClient(int id)
        {
            //arrange 
            var testClient = GetClientModelToFillRepositoryMock(id);
           
            var sut = new ClientService(_clientRepositoryMock.Object);
            //act 
            var actual = sut.InsertNewClient(testClient);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            
        }
        [TestCase(1)]

        public void DeleteClient_ShouldReturnDeleted(int id)
        {
            //arrange 
            var sut = new ClientService(_clientRepositoryMock.Object);
            var testClient=GetClientModelToFillRepositoryMock(id);
            //act 
            sut.DeleteClient(testClient);
            var a = sut.DeleteClient(testClient);
            //assert
            Assert.That(a, Is.EqualTo(true));


        }
        [TestCase(1)]

        public void UpDateClient_ShouldUpdate(int id)
        {
            //arrange
            var sut = new ClientService(_clientRepositoryMock.Object);
            var existingClient = GetClientModelToFillRepositoryMock(id);
            var actual = sut.UpdateClient(existingClient);
            Assert.IsTrue(actual);
        }

        public void GetAllComments_ShouldReturnComments()
        {
            
        }
    }
}