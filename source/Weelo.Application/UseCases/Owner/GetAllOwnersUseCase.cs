namespace Weelo.Application.UseCases.Owner
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Owner.GetAllOwners;
    using Weelo.Application.Gateway;
    using Weelo.Application.Utils;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class GetAllOwnersUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IOwnerGateway _ownerGateway;

        public GetAllOwnersUseCase(IOutputPort outputPort, IOwnerGateway ownerGateway) {
            _outputHandler = outputPort;
            _ownerGateway = ownerGateway;
        }

        public async Task Execute()
        {
            List<Owner> owners = await _ownerGateway.GetAllAsync();

            if (owners == null || owners.Count == 0) {
                _outputHandler.NotFound(Constants.OWNER_GET_ALL_NOT_FOUND);
                return;
            }

            GetAllOwnersOutput output = new GetAllOwnersOutput(owners);
            _outputHandler.Default(output, Constants.OWNER_GET_ALL_SUCCESSFULLY);
        }
    }
}