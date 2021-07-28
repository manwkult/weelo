namespace Weelo.API.UseCases.v1.Authentication
{
    using Microsoft.AspNetCore.Mvc;
    using Weelo.Application.Boundaries.Login;
    using Weelo.API.Responses;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using Weelo.API.Utils;

    public sealed class LoginPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        private readonly ILogger<LoginPresenter> _logger;
        private readonly IConfiguration _configuration;

        public LoginPresenter(ILogger<LoginPresenter> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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
            _logger.LogInformation(message);
        }

        public void Default(LoginOutput loginOutput, string message)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var token = TokenGenerator.GenerateTokenJwt(loginOutput.Data, secretKey);

            var response = new Response(1, new { Token = token, Email = loginOutput.Data.Email, Name = loginOutput.Data.Name }, message);
            ViewModel = new OkObjectResult(response);
        }
    }
}