namespace Weelo.UnitTest.API.PresenterTests
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using Weelo.API.Responses;
    using Weelo.API.UseCases.v1.Property.ChangePropertyPrice;
    using Weelo.Application.Boundaries.Property.ChangePropertyPrice;

    public class ChangePropertyPricePresenterTest
    {
        ChangePropertyPriceOutput output;

        Mock<ILogger<ChangePropertyPricePresenter>> loggerMock;
        ChangePropertyPricePresenter presenterMock;

        [SetUp]
        public void SetUp()
        {
            output = new ChangePropertyPriceOutput(true);
            loggerMock = new Mock<ILogger<ChangePropertyPricePresenter>>(); 
        }

        [Test]
        public void DefaultOkTest()
        {
            // Arrange
            var presenter = new ChangePropertyPricePresenter(loggerMock.Object);

            // Act
            presenter.Default(output, string.Empty);            

            // Assert
            var actual = (OkObjectResult) presenter.ViewModel;
            Assert.AreEqual((int) HttpStatusCode.OK, actual.StatusCode);

            var actualValue = (Response) actual.Value;
            Assert.AreEqual(output.Data, actualValue.Data);
        }

        [Test]
        public void ErrorOkTest()
        {
            // Arrange
            var presenter = new ChangePropertyPricePresenter(loggerMock.Object);

            // Act
            presenter.Error(string.Empty);            

            // Assert
            var actual = (BadRequestObjectResult) presenter.ViewModel;
            Assert.AreEqual((int) HttpStatusCode.BadRequest, actual.StatusCode);

            var actualValue = (Response) actual.Value;
            Assert.AreEqual(string.Empty, actualValue.Message);
        }
    }
}