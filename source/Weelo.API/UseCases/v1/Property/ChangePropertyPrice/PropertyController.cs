namespace Weelo.API.UseCases.v1.Property.ChangePropertyPrice
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Property.ChangePropertyPrice;
    using Weelo.Domain.Models;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly ChangePropertyPricePresenter _presenter;

        public PropertyController(IUseCase useCase, ChangePropertyPricePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Change property price
        /// </summary>
        /// <response code="200">Property price changed</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <returns>Confirmation of change property price</returns>
        [HttpPatch("price")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangePropertyPrice([FromBody][Required] ChangePropertyPriceRequest request)
        {
            var propertyPrice = new PropertyPrice()
            {
                Id = request.Id,
                Price = request.Price
            };
            var input = new ChangePropertyPriceInput(propertyPrice);

            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
