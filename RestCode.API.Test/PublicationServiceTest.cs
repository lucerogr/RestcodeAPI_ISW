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
    public class PublicationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ListAsyncWhenNoPublicationReturnsEmptyCollection()
        {
            // Arrange
            var mockPublicationRepository = GetDefaultIPublicationRepositoryInstance();
            mockPublicationRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Publication>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new PublicationService(
                mockPublicationRepository.Object,
                mockUnitOfWork.Object);
            // Act
            List<Publication> result = (List<Publication>)await service.ListAsync();
            int publicationCount = result.Count;
            // Assert
            publicationCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncInvalidIdReturnsPublicationNotFoundResponse()
        {
            // Arrange
            var mockPublicationRepository = GetDefaultIPublicationRepositoryInstance();
            var publicationId = 1;
            mockPublicationRepository.Setup(r => r.FindById(publicationId))
                .Returns(Task.FromResult<Publication>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new PublicationService(
                mockPublicationRepository.Object,
                mockUnitOfWork.Object);
            // Act
            PublicationResponse result = await service.GetByIdAsync(publicationId);
            var message = result.Message;
            // Assert
            message.Should().Be("Publication not found");
        }

        private Mock<IPublicationRepository> GetDefaultIPublicationRepositoryInstance()
        {
            return new Mock<IPublicationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}