namespace Weelo.UnitTest.API.PresenterTests
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using Weelo.API.Responses;
    using Weelo.API.UseCases.v1.Property.UpdateProperty;
    using Weelo.Application.Boundaries.Property.UpdateProperty;
    using Weelo.Domain.Models;

    public class UpdatePropertyPresenterTest
    {
        private object result;
        UpdatePropertyOutput output;

        Mock<ILogger<UpdatePropertyPresenter>> loggerMock;
        UpdatePropertyPresenter presenterMock;

        [SetUp]
        public void SetUp()
        {
            result = new {
                Id = 1,
                Name = string.Empty,
                Address = string.Empty,
                Price = 45000000,
                InternalCode = "INT",
                Year = 2021,
                Owner = new Owner(),
                PropertyImages = new List<PropertyImage>(),
                PropertyTraces = new List<PropertyTrace>(),
            };

            output = new UpdatePropertyOutput(result);
            loggerMock = new Mock<ILogger<UpdatePropertyPresenter>>(); 
        }

        [Test]
        public void DefaultOkTest()
        {
            // Arrange
            var presenter = new UpdatePropertyPresenter(loggerMock.Object);

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
            var presenter = new UpdatePropertyPresenter(loggerMock.Object);

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