using FluentAssertions;
using Moq;
using NUnit.Framework;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services.Communication;
using RestCode_WebApplication.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestCode.API.Test
{
    public class CommentServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ListAsyncWhenNoCommentReturnsEmptyCollection()
        {
            // Arrange
            var mockCommentRepository = GetDefaultICommentRepositoryInstance();
            mockCommentRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Comment>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CommentService(
                mockCommentRepository.Object,
                mockUnitOfWork.Object);
            // Act
            List<Comment> result = (List<Comment>)await service.ListAsync();
            int commentCount = result.Count;
            // Assert
            commentCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncInvalidIdReturnsCommentNotFoundResponse()
        {
            // Arrange
            var mockCommentRepository = GetDefaultICommentRepositoryInstance();
            var commentId = 1;
            mockCommentRepository.Setup(r => r.FindById(commentId))
                .Returns(Task.FromResult<Comment>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CommentService(
                mockCommentRepository.Object,
                mockUnitOfWork.Object);
            // Act
            CommentResponse result = await service.GetByIdAsync(commentId);
            var message = result.Message;
            // Assert
            message.Should().Be("Comment not found");
        }

        private Mock<ICommentRepository> GetDefaultICommentRepositoryInstance()
        {
            return new Mock<ICommentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
