namespace Weelo.API.UseCases.v1.Property.GetAllProperties
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Weelo.Application.Boundaries.Property.GetAllProperties;

    public sealed class GetAllPropertiesPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<GetAllPropertiesPresenter> _logger;

        public GetAllPropertiesPresenter(ILogger<GetAllPropertiesPresenter> logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new BadRequestObjectResult(response);
            _logger.LogError(message);
        }

        public void NotFound(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new NotFoundObjectResult(response);
        }

        public void Default(GetAllPropertiesOutput output, string message)
        {
            var response = new Response(1, output.Data, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}