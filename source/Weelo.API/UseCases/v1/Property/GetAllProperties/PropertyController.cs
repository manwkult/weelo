namespace Weelo.API.UseCases.v1.Property.GetAllProperties
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Property.GetAllProperties;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly GetAllPropertiesPresenter _presenter;

        public PropertyController(IUseCase useCase, GetAllPropertiesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// List of properties
        /// </summary>
        /// <response code="200">List of properties</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns>The list of properties</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            await _useCase.Execute();
            return _presenter.ViewModel;
        }
    }
}
