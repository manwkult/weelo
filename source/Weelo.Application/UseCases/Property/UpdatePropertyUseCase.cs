namespace Weelo.Application.UseCases.Property
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Property.UpdateProperty;
    using Weelo.Application.Gateway;
    using Weelo.Application.Utils;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class UpdatePropertyUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyGateway _propertyGateway;

        public UpdatePropertyUseCase(IOutputPort outputPort, IPropertyGateway propertyGateway) {
            _outputHandler = outputPort;
            _propertyGateway = propertyGateway;
        }

        public async Task Execute(UpdatePropertyInput input)
        {
           Property property = await _propertyGateway.AddOrUpdateAsync(input.Data);

            if (property == null) {
                _outputHandler.Error(Constants.PROPERTY_UPDATE_ERROR);
                return;
            }

            var data = ConvertData.getPropertyData(property);

            UpdatePropertyOutput output = new UpdatePropertyOutput(data);
            _outputHandler.Default(output, Constants.PROPERTY_UPDATE_SUCCESSFULLY);
        }
    }
}