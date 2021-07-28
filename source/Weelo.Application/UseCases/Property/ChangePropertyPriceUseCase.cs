namespace Weelo.Application.UseCases.Property
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Property.ChangePropertyPrice;
    using Weelo.Application.Gateway;
    using Weelo.Domain;

    public class ChangePropertyPriceUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IPropertyGateway _propertyGateway;

        public ChangePropertyPriceUseCase(IOutputPort outputPort, IPropertyGateway propertyGateway) {
            _outputHandler = outputPort;
            _propertyGateway = propertyGateway;
        }

        public async Task Execute(ChangePropertyPriceInput input)
        {
           var result = await _propertyGateway.ChangePriceAsync(input.Data);

           if (!result)
           {
               _outputHandler.Error(Constants.PROPERTY_CHANGE_PRICE_ERROR);
           }
           
           ChangePropertyPriceOutput output = new ChangePropertyPriceOutput(result);
           _outputHandler.Default(output, Constants.PROPERTY_CHANGE_PRICE_SUCCESSFULLY);
        }
    }
}