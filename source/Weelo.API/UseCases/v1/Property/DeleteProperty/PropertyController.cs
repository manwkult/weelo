namespace Weelo.API.UseCases.v1.Property.DeleteProperty
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Property.DeleteProperty;
    using Weelo.Domain.Models;
    using Weelo.Domain.ValueObjects;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly DeletePropertyPresenter _presenter;

        public PropertyController(IUseCase useCase, DeletePropertyPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Delete a property
        /// </summary>
        /// <response code="200">Property deleted</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperty([Required] long id)
        {
            await _useCase.Execute(new DeletePropertyInput(id));
            return _presenter.ViewModel;
        }
    }
}
