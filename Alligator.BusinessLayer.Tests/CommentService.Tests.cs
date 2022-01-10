using Alligator.BusinessLayer.Services;
using NUnit.Framework;
using Moq;
using Alligator.DataLayer.Repositories;
using Alligator.DataLayer;
using System.Collections.Generic;
using Alligator.DataLayer.Entities;
using Alligator.BusinessLayer.Models;

namespace Alligator.BusinessLayer.Tests
{
    public class CommentServiceTests
    {
        private readonly Mock<ICommentRepository> _commentRepositoryMock;
        private readonly Mock<IClientRepository>   _clientRepositoryMock;
        public CommentServiceTests()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _clientRepositoryMock = new Mock<IClientRepository>();

        }
        [SetUp]
        public void Setup()
        {
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
        public CommentModel GetCommentModelToFillRepositoryMock(int key)
        {
            CommentModel comment;
            switch (key)
            {
                case 1:
                    comment = new CommentModel
                    {
                        Id = 1,
                        Client = GetClientModelToFillRepositoryMock(1),
                        Text = "TestText1"
                    };
                    break;
                default:
                    comment = null;
                    break;
            }
            return comment;
        }

        [TestCase(1)]
        public void GetAllComments_ShouldReturnComments(int clientId)
        {
            _commentRepositoryMock.Setup(m => m.GetAllCommentsByCLientId(clientId)).Returns(new List<Comment>
            {
                new Comment()
                {
                    Id = 1,
                    Text = "TestText1"
                }
            });
            var commentService = new CommentService(_commentRepositoryMock.Object);
            var actual = commentService.GetAllComments(clientId);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
            _commentRepositoryMock.Verify(m => m.GetAllCommentsByCLientId(clientId), Times.Once());
            Assert.IsTrue(actual.Data.Count > 0);
            Assert.IsInstanceOf(typeof(CommentModel), actual.Data[0]);
        }

        [TestCase(1)]
        public void InsertComment_ShouldInsertComment(int key)
        {
            var comment = GetCommentModelToFillRepositoryMock(key);
           _commentRepositoryMock.Setup(m => m.InsertCommentById(comment.Id, comment.Text));
            var commentService = new CommentService(_commentRepositoryMock.Object);
            var actual = commentService.InsertComment(comment);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
        }

        [TestCase(1)]
        public void DeleteCommentsByClient_ShouldDeleteComments(int clientId)
        {

            _commentRepositoryMock.Setup(m => m.DeleteCommentByClientId(clientId));
            var commentService = new CommentService(_commentRepositoryMock.Object);
            var actual = commentService.DeleteCommentsByClientId(clientId);
            Assert.IsTrue(actual);
            
        }

    }
}
