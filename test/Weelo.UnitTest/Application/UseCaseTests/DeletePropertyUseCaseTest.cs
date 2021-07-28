namespace Weelo.UnitTest.Application.UseCaseTests
{
    using Weelo.Application.UseCases.Property;
    using Weelo.Application.Boundaries.Property.DeleteProperty;
    using Weelo.Application.Gateway;
    using NUnit.Framework;
    using Moq;
    using System.Threading.Tasks;

    public class DeletePropertyUseCaseTest
    {
        private DeletePropertyInput input;
        private DeletePropertyOutput output;

        Mock<IOutputPort> outputHandlerMock;
        Mock<IPropertyGateway> propertyGatewayMock;

        [SetUp]
        public void SetUp()
        {
            input = new DeletePropertyInput(1);
            output = new DeletePropertyOutput(true);

            outputHandlerMock = new Mock<IOutputPort>();
        }

        [Test]
        public async Task DeletePropertyOkTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.DeleteAsync(It.IsAny<long>()))
                .ReturnsAsync(true);

            // Arrange
            var deletePropertyUseCase = new DeletePropertyUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await deletePropertyUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.DeleteAsync(It.IsAny<long>()), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Default(It.IsAny<DeletePropertyOutput>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task DeletePropertyFailTest()
        {
            propertyGatewayMock = new Mock<IPropertyGateway>();
            propertyGatewayMock
                .Setup(x => x.DeleteAsync(It.IsAny<long>()))
                .ReturnsAsync(false);
            
            // Arrange
            var deletePropertyUseCase = new DeletePropertyUseCase(outputHandlerMock.Object, propertyGatewayMock.Object);

            // Act
            await deletePropertyUseCase.Execute(input);

            // Assert
            propertyGatewayMock.Verify(x =>
                x.DeleteAsync(It.IsAny<long>()), Times.Once);

            outputHandlerMock.Verify(x =>
                x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}