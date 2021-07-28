namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Adapter
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Weelo.Application.Gateway;
    using Weelo.Domain.Models;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service;

    public class PropertyRepositoryAdapter : IPropertyGateway
    {
        private readonly IPropertyService _propertyService;
        private readonly IPropertyImageService _propertyImageService;
        private readonly IMapper _mapper;

        public PropertyRepositoryAdapter(IPropertyService propertyService, IPropertyImageService propertyImageService, IMapper mapper)
        {
            _propertyService = propertyService;
            _propertyImageService = propertyImageService;
            _mapper = mapper;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            List<Property> properties = new List<Property>();
            var propertyEntities = await _propertyService.GetAllWhitOwnerAsync();

            propertyEntities.ForEach(propertyEntity => {
                var property = _mapper.Map<Property>(propertyEntity);
                properties.Add(property);
            });

            return properties;
        }

        public async Task<Property> AddOrUpdateAsync(Property property)
        {
            var propertyEntity = _mapper.Map<PropertyEntity>(property);
            propertyEntity.OwnerId = propertyEntity.Owner.Id;
            propertyEntity.Owner = null;
            
            propertyEntity = await _propertyService.AddOrUpdateAsync(propertyEntity);

            if (propertyEntity.Id > 0) {
                await _propertyImageService.RemoveByPropertyIdAsync(propertyEntity.Id);

                foreach (PropertyImage propertyImage in property.PropertyImages)
                {
                    var propertyImageEntity = new PropertyImageEntity
                    {
                        Id = 0,
                        File = propertyImage.File,
                        Enabled = propertyImage.Enabled,
                        PropertyId = propertyEntity.Id
                    };
                    await _propertyImageService.AddOrUpdateAsync(propertyImageEntity);
                }
            }

            return _mapper.Map<Property>(propertyEntity);
        }

        public async Task<bool> ChangePriceAsync(PropertyPrice propertyPrice)
        {
            return await _propertyService.ChangePriceAsync(propertyPrice.Id, propertyPrice.Price);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _propertyService.RemoveAsync(new PropertyEntity() { Id = id });
        }
    }
}