namespace Weelo.UnitTest.Application.UseCaseTests
{
    using Weelo.Application.UseCases.Property;
    using Weelo.Application.Boundaries.Property.UpdateProperty;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using NUnit.Framework;
    using Moq;
    using System.Threading.Tasks;
    using Weelo.Domain.ValueObjects;

    public class UpdatePropertyUseCaseTest
    {
        private Property property;
        private UpdatePropertyInput input;
        private UpdatePropertyOutput output;

        Mock<IOutputPort> outputHandlerMock;
        Mock<IPropertyGateway> propertyGatewayMock;

        [SetUp]
        public void SetUp()
        {
            property = new Property()
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
            };
            input = new UpdatePropertyInput(property);
            output = new UpdatePropertyOutput(property);

            outputHandlerMock = new Mock<IOutputPort>();
        }

        [Test]
        public async Task UpdatePropertyOkTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.AddOrUpdateAsync(It.IsAny<Property>()))
                .ReturnsAsync(property);

            // Arrange
            var updatePropertyUseCase = new UpdatePropertyUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await updatePropertyUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.AddOrUpdateAsync(It.IsAny<Property>()), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Default(It.IsAny<UpdatePropertyOutput>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task UpdatePropertyFailTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.AddOrUpdateAsync(It.IsAny<Property>()))
                .Returns(Task.FromResult<Property>(null));
            
            // Arrange
            var updatePropertyUseCase = new UpdatePropertyUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await updatePropertyUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.AddOrUpdateAsync(It.IsAny<Property>()), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}