namespace Weelo.Application.UseCases.Owner
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Owner.CreateOwner;
    using Weelo.Application.Gateway;
    using Weelo.Application.Utils;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class CreateOwnerUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IOwnerGateway _ownerGateway;

        public CreateOwnerUseCase(IOutputPort outputPort, IOwnerGateway ownerGateway) {
            _outputHandler = outputPort;
            _ownerGateway = ownerGateway;
        }

        public async Task Execute(CreateOwnerInput input)
        {
           Owner owner = await _ownerGateway.AddOrUpdateAsync(input.Data);

            if (owner == null) {
                _outputHandler.Error(Constants.OWNER_CREATE_ERROR);
                return;
            }

            CreateOwnerOutput output = new CreateOwnerOutput(owner);
            _outputHandler.Default(output, Constants.OWNER_CREATE_SUCCESSFULLY);
        }
    }
}