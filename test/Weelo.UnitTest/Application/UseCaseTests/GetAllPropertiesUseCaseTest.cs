namespace Weelo.UnitTest.Application.UseCaseTests
{
    using Weelo.Application.UseCases.Property;
    using Weelo.Application.Boundaries.Property.GetAllProperties;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using NUnit.Framework;
    using Moq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Weelo.Domain.ValueObjects;

    public class GetAllPropertiesUseCaseTest
    {
        private List<Property> properties;

        private GetAllPropertiesOutput output;

        Mock<IOutputPort> outputHandlerMock;
        Mock<IPropertyGateway> propertyGatewayMock;

        [SetUp]
        public void SetUp()
        {
            properties = new List<Property>();
            properties.Add(new Property()
            {
                Id = 1,
                Name = "Test",
                Address = "Test",
                Price = 200000000,
                InternalCode = new ValidInternalCode("INT"),
                Year = 2021,
                Owner = new Owner()
                {
                    Id = 1
                }
            });
            output = new GetAllPropertiesOutput(true);

            outputHandlerMock = new Mock<IOutputPort>();
        }

        [Test]
        public async Task GetAllPropertiesOkTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(properties);

            // Arrange
            var getAllPropertiesUseCase = new GetAllPropertiesUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await getAllPropertiesUseCase.Execute();

            // Assert
            propertyGatewayMock.Verify(x =>
                x.GetAllAsync(), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Default(It.IsAny<GetAllPropertiesOutput>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task GetAllPropertiesFailTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Property>());
            
            // Arrange
            var getAllPropertiesUseCase = new GetAllPropertiesUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await getAllPropertiesUseCase.Execute();

            // Assert
            propertyGatewayMock.Verify(x =>
                x.GetAllAsync(), Times.Once);

            outputHandlerMock.Verify(x =>
                x.NotFound(It.IsAny<string>()), Times.Once);
        }
    }
}