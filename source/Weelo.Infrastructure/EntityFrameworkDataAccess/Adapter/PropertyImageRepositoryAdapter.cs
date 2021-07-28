namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Adapter
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service;

    public class PropertyTraceRepositoryAdapter : IPropertyTraceGateway
    {
        private readonly IPropertyTraceService _propertyTraceService;
        private readonly IMapper _mapper;

        public PropertyTraceRepositoryAdapter(IPropertyTraceService propertyTraceService, IMapper mapper)
        {
            _propertyTraceService = propertyTraceService;
            _mapper = mapper;
        }

        public async Task<PropertyTrace> AddOrUpdateAsync(PropertyTrace propertyTrace)
        {
            var propertyTraceEntity = _mapper.Map<PropertyTraceEntity>(propertyTrace);
            
            propertyTraceEntity = await _propertyTraceService.AddOrUpdateAsync(propertyTraceEntity);
            return _mapper.Map<PropertyTrace>(propertyTraceEntity);
        }
    }
}