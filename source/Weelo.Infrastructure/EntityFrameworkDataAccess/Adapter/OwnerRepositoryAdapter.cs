namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Adapter
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service;

    public class OwnerRepositoryAdapter : IOwnerGateway
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerRepositoryAdapter(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public async Task<List<Owner>> GetAllAsync()
        {
            List<Owner> properties = new List<Owner>();
            var ownerEntities = await _ownerService.GetAllAsync();

            ownerEntities.ForEach(ownerEntity => {
                var owner = _mapper.Map<Owner>(ownerEntity);
                properties.Add(owner);
            });

            return properties;
        }

        public async Task<Owner> AddOrUpdateAsync(Owner owner)
        {
            var ownerEntity = _mapper.Map<OwnerEntity>(owner);
            
            ownerEntity = await _ownerService.AddOrUpdateAsync(ownerEntity);
            return _mapper.Map<Owner>(ownerEntity);
        }
    }
}