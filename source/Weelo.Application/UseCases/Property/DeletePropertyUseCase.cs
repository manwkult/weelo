namespace Weelo.Application.UseCases.Property
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Property.DeleteProperty;
    using Weelo.Application.Gateway;
    using Weelo.Domain;
    
    public class DeletePropertyUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyGateway _propertyGateway;

        public DeletePropertyUseCase(IOutputPort outputPort, IPropertyGateway propertyGateway) {
            _outputHandler = outputPort;
            _propertyGateway = propertyGateway;
        }

        public async Task Execute(DeletePropertyInput input)
        {
           bool deleted = await _propertyGateway.DeleteAsync(input.Id);

            if (!deleted) {
                _outputHandler.Error(Constants.PROPERTY_DELETE_ERROR);
                return;
            }

            DeletePropertyOutput output = new DeletePropertyOutput(deleted);
            _outputHandler.Default(output, Constants.PROPERTY_DELETE_SUCCESSFULLY);
        }
    }
}