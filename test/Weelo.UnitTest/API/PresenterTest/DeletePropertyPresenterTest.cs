namespace Weelo.UnitTest.API.PresenterTests
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using Weelo.API.Responses;
    using Weelo.API.UseCases.v1.Property.DeleteProperty;
    using Weelo.Application.Boundaries.Property.DeleteProperty;
    using Weelo.Domain.Models;

    public class DeletePropertyPresenterTest
    {
        DeletePropertyOutput output;

        Mock<ILogger<DeletePropertyPresenter>> loggerMock;
        DeletePropertyPresenter presenterMock;

        [SetUp]
        public void SetUp()
        {
            output = new DeletePropertyOutput(true);
            loggerMock = new Mock<ILogger<DeletePropertyPresenter>>(); 
        }

        [Test]
        public void DefaultOkTest()
        {
            // Arrange
            var presenter = new DeletePropertyPresenter(loggerMock.Object);

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
            var presenter = new DeletePropertyPresenter(loggerMock.Object);

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