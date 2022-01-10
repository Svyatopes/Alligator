using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
