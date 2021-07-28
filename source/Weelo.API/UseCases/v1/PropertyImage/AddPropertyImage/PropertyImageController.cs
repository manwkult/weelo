namespace Weelo.API.UseCases.v1.PropertyImage.AddPropertyImage
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.PropertyImage.AddPropertyImage;
    using Weelo.Domain.Models;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PropertyImageController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly AddPropertyImagePresenter _presenter;

        public PropertyImageController(IUseCase useCase, AddPropertyImagePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Add property image
        /// </summary>
        /// <response code="201">Property image added</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns>The Property image added</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperty([FromBody][Required] AddPropertyImageRequest request)
        {
            var propertyImage = new PropertyImage()
            {
                File = request.File,
                Enabled = request.Enabled,
                PropertyId = request.PropertyId
            };

            var input = new AddPropertyImageInput(propertyImage);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
