namespace Weelo.API.UseCases.v1.Property.ChangePropertyPrice
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Weelo.Application.Boundaries.Property.ChangePropertyPrice;

    public sealed class ChangePropertyPricePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<ChangePropertyPricePresenter> _logger;

        public ChangePropertyPricePresenter(ILogger<ChangePropertyPricePresenter> logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            var response = new Response(0, null, message);
            ViewModel = new BadRequestObjectResult(response);
            _logger.LogError(message);
        }

        public void Default(ChangePropertyPriceOutput output, string message)
        {
            var response = new Response(1, output.Data, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}