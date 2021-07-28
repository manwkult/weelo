namespace Weelo.API.UseCases.v1.Property.CreateProperty
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Property.CreateProperty;
    using Weelo.Domain.Models;
    using Weelo.Domain.ValueObjects;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly CreatePropertyPresenter _presenter;

        public PropertyController(IUseCase useCase, CreatePropertyPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Add a property
        /// </summary>
        /// <response code="201">Property added</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns>The Property added</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperty([FromBody][Required] CreatePropertyRequest request)
        {
            var property = new Property()
            {
                Name = request.Name,
                Address = request.Address,
                Price = request.Price,
                InternalCode = new ValidInternalCode(request.InternalCode),
                Year = request.Year,
                Owner = new Owner()
                {
                    Id = request.OwnerId
                },
                PropertyImages = request.PropertyImages
            };

            var input = new CreatePropertyInput(property);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
