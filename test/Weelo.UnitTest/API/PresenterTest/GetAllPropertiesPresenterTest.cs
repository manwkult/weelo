namespace Weelo.UnitTest.API.PresenterTests
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using Weelo.API.Responses;
    using Weelo.API.UseCases.v1.Property.GetAllProperties;
    using Weelo.Application.Boundaries.Property.GetAllProperties;
    using Weelo.Domain.Models;

    public class GetAllPropertiesPresenterTest
    {
        private object result;
        GetAllPropertiesOutput output;

        Mock<ILogger<GetAllPropertiesPresenter>> loggerMock;
        GetAllPropertiesPresenter presenterMock;

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
            List<object> results = new List<object>();
            results.Add(result);

            output = new GetAllPropertiesOutput(results);
            loggerMock = new Mock<ILogger<GetAllPropertiesPresenter>>(); 
        }

        [Test]
        public void DefaultOkTest()
        {
            // Arrange
            var presenter = new GetAllPropertiesPresenter(loggerMock.Object);

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
            var presenter = new GetAllPropertiesPresenter(loggerMock.Object);

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