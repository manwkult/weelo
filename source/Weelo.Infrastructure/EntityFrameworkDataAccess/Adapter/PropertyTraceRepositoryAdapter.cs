namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Adapter
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service;

    public class PropertyImageRepositoryAdapter : IPropertyImageGateway
    {
        private readonly IPropertyImageService _propertyImageService;
        private readonly IMapper _mapper;

        public PropertyImageRepositoryAdapter(IPropertyImageService propertyImageService, IMapper mapper)
        {
            _propertyImageService = propertyImageService;
            _mapper = mapper;
        }

        public async Task<PropertyImage> AddOrUpdateAsync(PropertyImage propertyImage)
        {
            var propertyImageEntity = _mapper.Map<PropertyImageEntity>(propertyImage);
            
            propertyImageEntity = await _propertyImageService.AddOrUpdateAsync(propertyImageEntity);
            return _mapper.Map<PropertyImage>(propertyImageEntity);
        }
    }
}