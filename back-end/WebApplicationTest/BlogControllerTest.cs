using Business;
using Common;
using Common.Entities;
using Moq;
using System;
using WebApplication.Controllers;
using Xunit;

namespace WebApplicationTest
{
    public class BlogControllerTest
    {
        private readonly BlogController blogController;
        private readonly Mock<IBlogBL> iBlogBLMock;

        public BlogControllerTest()
        {
            iBlogBLMock = new Mock<IBlogBL>();
            blogController = new BlogController(iBlogBLMock.Object);
        }

        [Fact]
        public void Insert()
        {
            //Arrange
            

            //Act


            //Assert
        }


        [Fact]
        public void ApproveOrReject()
        {
            //Arrange
            Guid id = Guid.Parse("2D700B21-CAD9-4513-AAAB-F358AE8DFF52");
            Enums.Action action = Enums.Action.Approve;

            //Act
            blogController.ApproveOrReject(id, action);

            //Assert
        }
    }
}
