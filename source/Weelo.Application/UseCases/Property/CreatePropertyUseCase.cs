namespace Weelo.Application.UseCases.Property
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Property.CreateProperty;
    using Weelo.Application.Gateway;
    using Weelo.Application.Utils;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class CreatePropertyUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyGateway _propertyGateway;

        public CreatePropertyUseCase(IOutputPort outputPort, IPropertyGateway propertyGateway) {
            _outputHandler = outputPort;
            _propertyGateway = propertyGateway;
        }

        public async Task Execute(CreatePropertyInput input)
        {
            Property property = await _propertyGateway.AddOrUpdateAsync(input.Data);

            if (property == null) {
                _outputHandler.Error(Constants.PROPERTY_CREATE_ERROR);
                return;
            }

            var data = ConvertData.getPropertyData(property);

            CreatePropertyOutput output = new CreatePropertyOutput(data);
            _outputHandler.Default(output, Constants.PROPERTY_CREATE_SUCCESSFULLY);
        }
    }
}