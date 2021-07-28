namespace Weelo.UnitTest.Application.UseCaseTests
{
    using Weelo.Application.UseCases.Property;
    using Weelo.Application.Boundaries.Property.ChangePropertyPrice;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using NUnit.Framework;
    using Moq;
    using System.Threading.Tasks;

    public class ChangePropertyPriceUseCaseTest
    {
        private ChangePropertyPriceInput input;
        private ChangePropertyPriceOutput output;

        Mock<IOutputPort> outputHandlerMock;
        Mock<IPropertyGateway> propertyGatewayMock;

        [SetUp]
        public void SetUp()
        {
            input = new ChangePropertyPriceInput(new PropertyPrice() { Id = 1, Price = 200000000 });
            output = new ChangePropertyPriceOutput(true);

            outputHandlerMock = new Mock<IOutputPort>();
        }

        [Test]
        public async Task ChangePropertyPriceOkTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.ChangePriceAsync(input.Data))
                .ReturnsAsync(true);

            // Arrange
            var changePropertyPriceUseCase = new ChangePropertyPriceUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await changePropertyPriceUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.ChangePriceAsync(input.Data), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Default(It.IsAny<ChangePropertyPriceOutput>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task ChangePropertyPriceFailTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.ChangePriceAsync(input.Data))
                .ReturnsAsync(false);
            
            // Arrange
            var changePropertyPriceUseCase = new ChangePropertyPriceUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await changePropertyPriceUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.ChangePriceAsync(input.Data), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}