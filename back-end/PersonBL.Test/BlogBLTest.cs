using Common;
using Common.Entities;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Test
{
    public class BlogBLTest
    {
        private readonly IBlogBL iBlogBL;
        private readonly Mock<IBlogDA> iBlogDAMock;

        public BlogBLTest()
        {
            iBlogDAMock = new Mock<IBlogDA>();
            iBlogBL = new BlogBL(iBlogDAMock.Object);
        }


        [Fact]
        public void ApproveOrRejectTest_Approve()
        {
            //Arrange
            Guid blogId = Guid.NewGuid();

            Blog blog = new Blog();
            blog.Id = blogId; 
            blog.State.Id = Guid.NewGuid();

            iBlogDAMock.Setup(x => x.GetById(blogId)).Returns(blog);

            //Act
            iBlogBL.ApproveOrReject(blogId, Enums.Action.Approve);

            //Assert
            Assert.Equal(Guid.Parse(Enums.BlogState.Approved.GetValueByProperty(Enums.Property.Id)), blog.State.Id);
            Assert.True(blog.PublishDate != null);
        }


        [Fact]
        public void ApproveOrRejectTest_Reject()
        {
            //Arrange
            Guid blogId = Guid.NewGuid();

            Blog blog = new Blog();
            blog.Id = blogId;
            blog.State.Id = Guid.NewGuid();

            iBlogDAMock.Setup(x => x.GetById(blogId)).Returns(blog);

            //Act
            iBlogBL.ApproveOrReject(blogId, Enums.Action.Reject);

            //Assert
            Assert.Equal(Guid.Parse(Enums.BlogState.Rejected.GetValueByProperty(Enums.Property.Id)), blog.State.Id);
            Assert.True(blog.PublishDate == null);
        }
    }
}
