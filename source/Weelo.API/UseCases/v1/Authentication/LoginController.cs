namespace Weelo.API.UseCases.v1.Authentication
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Login;
    using Weelo.Domain.Models;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly LoginPresenter _presenter;

        public LoginController(IUseCase useCase, LoginPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <response code="200">User Authenticated</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns>User Authenticated</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody][Required] LoginRequest request)
        {
            var input = new LoginInput(new User() { Username = request.Username, Password = request.Password });
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
