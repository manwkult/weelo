namespace Weelo.UnitTest.Infraestructure.AdapterTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Moq;
    using NUnit.Framework;
    using Weelo.Domain.Models;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Adapter;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service;

    public class OwnerRepositoryAdapterTest
    {
        OwnerEntity ownerEntity;
        Owner owner;
        List<OwnerEntity> ownerEntities;
        List<Owner> owners;

        Mock<IOwnerService> ownerServiceMock;
        Mock<IMapper> mapperMock;

        [SetUp]
        public void SetUp()
        {
            owner = new Owner()
            {
                Id = 1,
                Name = string.Empty,
                Address = string.Empty,
                Photo = string.Empty,
                Birthday = DateTime.Now
            };

            ownerEntity = new OwnerEntity()
            {
                Id = 1,
                Name = string.Empty,
                Address = string.Empty,
                Photo = string.Empty,
                Birthday = DateTime.Now
            };

            owners = new List<Owner>();
            owners.Add(owner);

            ownerEntities = new List<OwnerEntity>();
            ownerEntities.Add(ownerEntity);

            ownerServiceMock = new Mock<IOwnerService>();
            mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task GetAllAsyncOkTest()
        {
            ownerServiceMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(ownerEntities);
            
            mapperMock
                .Setup(x => x.Map<Owner>(It.IsAny<OwnerEntity>()))
                .Returns(owner);

            // Arrange
            var adapter = new OwnerRepositoryAdapter(ownerServiceMock.Object, mapperMock.Object);

            // Act
            var result = await adapter.GetAllAsync();

            // Assert
            Assert.AreEqual(result.Count, owners.Count);

            ownerServiceMock.Verify(x =>
                x.GetAllAsync(), Times.Once);

            mapperMock.Verify(x =>
                x.Map<Owner>(It.IsAny<OwnerEntity>()), Times.Once);
        }

        [Test]
        public async Task GetAllAsyncEmptyTest()
        {
            var empty = new List<OwnerEntity>();

            ownerServiceMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(empty);

            // Arrange
            var adapter = new OwnerRepositoryAdapter(ownerServiceMock.Object, mapperMock.Object);

            // Act
            var result = await adapter.GetAllAsync();

            // Assert
            Assert.AreEqual(result.Count, empty.Count);

            ownerServiceMock.Verify(x =>
                x.GetAllAsync(), Times.Once);

            mapperMock.Verify(x =>
                x.Map<Owner>(It.IsAny<OwnerEntity>()), Times.Never);
        }

        [Test]
        public async Task AddOrUpdateOkTest()
        {
            ownerServiceMock
                .Setup(x => x.AddOrUpdateAsync(It.IsAny<OwnerEntity>()))
                .ReturnsAsync(ownerEntity);

            mapperMock
                .Setup(x => x.Map<Owner>(It.IsAny<OwnerEntity>()))
                .Returns(owner);

            // Arrange
            var adapter = new OwnerRepositoryAdapter(ownerServiceMock.Object, mapperMock.Object);

            // Act
            var result = await adapter.AddOrUpdateAsync(owner);

            // Assert
            Assert.AreEqual(result, owner);

            ownerServiceMock.Verify(x =>
                x.AddOrUpdateAsync(It.IsAny<OwnerEntity>()), Times.Once);

            mapperMock.Verify(x =>
                x.Map<OwnerEntity>(It.IsAny<Owner>()), Times.Once);
        }
    }
}