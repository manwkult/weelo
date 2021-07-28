namespace Weelo.API.UseCases.v1.Property.CreateProperty
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Weelo.Application.Boundaries.Property.CreateProperty;

    public sealed class CreatePropertyPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<CreatePropertyPresenter> _logger;

        public CreatePropertyPresenter(ILogger<CreatePropertyPresenter> logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new BadRequestObjectResult(response);
            _logger.LogError(message);
        }

        public void Default(CreatePropertyOutput output, string message)
        {
            var response = new Response(1, output.Data, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}