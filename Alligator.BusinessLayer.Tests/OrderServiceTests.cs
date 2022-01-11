using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using Moq;
using NUnit.Framework;

namespace Alligator.BusinessLayer.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IOrderDetailRepository> _orderDetailRepositoryMock;
        private readonly Mock<IOrderReviewRepository> _orderReviewRepositoryMock;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderDetailRepositoryMock = new Mock<IOrderDetailRepository>();
            _orderReviewRepositoryMock = new Mock<IOrderReviewRepository>();
        }
        [SetUp]
        public void Setup()
        {
        }
        public void FillObjectMockForGetAllOrders()
        {
            _orderRepositoryMock.Setup(m => m.GetAllOrders()).Returns(new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Address = "TestAdress1",
                    Client = new Client(),
                    OrderDetails=new List<OrderDetail>(),
                    OrderReviews =new List<OrderReview>()

                },
                new Order
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Address = "TestAdress1",
                    Client = new Client(),
                    OrderDetails=new List<OrderDetail>(),
                    OrderReviews =new List<OrderReview>()
                },
                new Order
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Address = "TestAdress1",
                    Client = new Client(),
                    OrderDetails=new List<OrderDetail>(),
                    OrderReviews =new List<OrderReview>()
                }
            });
        }

        public void FillObjectMockForGetOrderById()
        {
            _orderRepositoryMock.Setup(m => m.GetOrderById(1)).Returns(new Order
            {
                Id = 1,
                Date = DateTime.Now,
                Address = "TestAdress1",
                Client = new Client(),
                OrderDetails = new List<OrderDetail>(),
                OrderReviews = new List<OrderReview>()

            });
            _orderRepositoryMock.Setup(m => m.GetOrderById(2)).Returns(new Order
            {
                Id = 2,
                Date = DateTime.Now,
                Address = "TestAdress1",
                Client = new Client(),
                OrderDetails = new List<OrderDetail>(),
                OrderReviews = new List<OrderReview>()

            });
            _orderRepositoryMock.Setup(m => m.GetOrderById(3)).Returns(new Order
            {
                Id = 3,
                Date = DateTime.Now,
                Address = "TestAdress1",
                Client = new Client(),
                OrderDetails = new List<OrderDetail>(),
                OrderReviews = new List<OrderReview>()

            });
        }

        public OrderModel GetTestOrdersModelToFill(int key)
        {
            OrderModel order;
            switch (key)
            {
                case 1:
                    order = new OrderModel
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Address = "TestAdress1",
                        Client = new ClientModel(),
                        OrderDetails = new List<OrderDetailModel>(),
                        OrderReviews = new List<OrderReviewModel>()
                    };
                    break;

                case 2:
                    order = new OrderModel
                    {
                        Id = 2,
                        Date = DateTime.Now,
                        Address = "TestAdress1",
                        Client = new ClientModel(),
                        OrderDetails = new List<OrderDetailModel>(),
                        OrderReviews = new List<OrderReviewModel>()
                    };
                    break;
                case 3:
                    order = new OrderModel
                    {
                        Id = 3,
                        Date = DateTime.Now,
                        Address = "TestAdress1",
                        Client = new ClientModel(),
                        OrderDetails = new List<OrderDetailModel>(),
                        OrderReviews = new List<OrderReviewModel>()
                    };
                    break;
                default:
                    order = null;
                    break;
            }
            return order;
        } 

        [Test]
        public void GetOrders_ShouldReturnAllOrders()
        {
            //arrange

            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object );
            FillObjectMockForGetAllOrders();
            //act
            var actual = sut.GetOrders().Data;
            //assert            
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(OrderModel), actual[0]);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetOrderByOrderId_ShouldReturnOrder(int id)
        {
            //arrange            

            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object);
            FillObjectMockForGetOrderById();
              var actual = sut.GetOrderByIdWithDetailsAndReviews(id);
            _orderRepositoryMock.Verify(m => m.GetOrderById(id), Times.Once());

            Assert.IsTrue(actual.Success);
            Assert.IsTrue(actual.Data.Id == id);
            Assert.IsNotNull(actual.Data);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetOrderByClientId_ShouldReturnOrder(int id)
        {
            //arrange            

            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object);
            FillObjectMockForGetOrderById();
            var actual = sut.GetOrdersByClientId(id);
            _orderRepositoryMock.Verify(m => m.GetOrdersByClientId(id), Times.Once());

            Assert.IsTrue(actual.Success);         
            Assert.IsNotNull(actual.Data);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public void AddOrderModel(int id)
        {
            //arrange 
            var testOrder = GetTestOrdersModelToFill(id);
            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object);
            //act 
            var actual = sut.AddOrderModel(testOrder.Date, testOrder.Client.Id, testOrder.Address);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteClient_ShouldReturnDeleted(int id)
        {
            //arrange 
            var testOrder = GetTestOrdersModelToFill(id);
            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object);
            //act 
            var a = sut.DeleteOrderModel(testOrder.Id); 
            //assert
            Assert.That(a, Is.EqualTo(true));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void EditOrderModel_ShouldEdited(int id)
        {
            var existingOrder = GetTestOrdersModelToFill(id);
            var sut = new OrderService(_orderRepositoryMock.Object, _orderDetailRepositoryMock.Object, _orderReviewRepositoryMock.Object);
            var actual = sut.EditOrderModel(existingOrder);
            Assert.IsTrue(actual);
        }
    }
    }

