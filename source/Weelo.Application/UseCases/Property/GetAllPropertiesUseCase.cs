namespace Weelo.Application.UseCases.Property
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Property.GetAllProperties;
    using Weelo.Application.Gateway;
    using Weelo.Application.Utils;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class GetAllPropertiesUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyGateway _propertyGateway;

        public GetAllPropertiesUseCase(IOutputPort outputPort, IPropertyGateway propertyGateway) {
            _outputHandler = outputPort;
            _propertyGateway = propertyGateway;
        }

        public async Task Execute()
        {
            List<Property> properties = await _propertyGateway.GetAllAsync();

            if (properties == null || properties.Count == 0) {
                _outputHandler.NotFound(Constants.PROPERTY_GET_ALL_NOT_FOUND);
                return;
            }

            var data = properties.Select(p => ConvertData.getPropertyData(p));

            GetAllPropertiesOutput output = new GetAllPropertiesOutput(data);
            _outputHandler.Default(output, Constants.PROPERTY_GET_ALL_SUCCESSFULLY);
        }
    }
}