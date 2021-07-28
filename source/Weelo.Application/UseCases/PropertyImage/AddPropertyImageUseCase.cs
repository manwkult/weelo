namespace Weelo.Application.UseCases.PropertyImage
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.PropertyImage.AddPropertyImage;
    using Weelo.Application.Gateway;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class AddPropertyImageUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyImageGateway _propertyImageGateway;

        public AddPropertyImageUseCase(IOutputPort outputPort, IPropertyImageGateway propertyImageGateway) {
            _outputHandler = outputPort;
            _propertyImageGateway = propertyImageGateway;
        }

        public async Task Execute(AddPropertyImageInput input)
        {
           PropertyImage propertyImage = await _propertyImageGateway.AddOrUpdateAsync(input.Data);

            if (propertyImage == null) {
                _outputHandler.Error(Constants.PROPERTY_IMAGE_CREATE_ERROR);
                return;
            }

            AddPropertyImageOutput output = new AddPropertyImageOutput(propertyImage);
            _outputHandler.Default(output, Constants.PROPERTY_IMAGE_CREATE_SUCCESSFULLY);
        }
    }
}