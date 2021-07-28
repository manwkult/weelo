namespace Weelo.API.UseCases.v1.Owner.CreateOwner
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Weelo.API.Responses;
    using Weelo.Application.Boundaries.Owner.CreateOwner;
    using Weelo.Domain.Models;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        private readonly IUseCase _useCase;
        private readonly CreateOwnerPresenter _presenter;

        public OwnerController(IUseCase useCase, CreateOwnerPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Add a property
        /// </summary>
        /// <response code="201">Owner added</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Error.</response>
        /// <returns>The Owner added</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOwner([FromBody][Required] CreateOwnerRequest request)
        {
            var property = new Owner()
            {
                Name = request.Name,
                Address = request.Address,
                Photo = request.Photo,
                Birthday = request.Birthday,
            };

            var input = new CreateOwnerInput(property);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
