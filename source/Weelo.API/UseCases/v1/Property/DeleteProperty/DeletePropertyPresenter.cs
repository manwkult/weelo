namespace Weelo.API.UseCases.v1.Property.DeleteProperty
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Weelo.Application.Boundaries.Property.DeleteProperty;

    public sealed class DeletePropertyPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<DeletePropertyPresenter> _logger;

        public DeletePropertyPresenter(ILogger<DeletePropertyPresenter> logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new BadRequestObjectResult(response);
            _logger.LogError(message);
        }

        public void Default(DeletePropertyOutput output, string message)
        {
            var response = new Response(1, output.Data, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}