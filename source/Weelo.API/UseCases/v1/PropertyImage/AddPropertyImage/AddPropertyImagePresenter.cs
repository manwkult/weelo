namespace Weelo.API.UseCases.v1.PropertyImage.AddPropertyImage
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Weelo.Application.Boundaries.PropertyImage.AddPropertyImage;

    public sealed class AddPropertyImagePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<AddPropertyImagePresenter> _logger;

        public AddPropertyImagePresenter(ILogger<AddPropertyImagePresenter> logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new BadRequestObjectResult(response);
            _logger.LogError(message);
        }

        public void Default(AddPropertyImageOutput output, string message)
        {
            var response = new Response(1, output.Data, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}