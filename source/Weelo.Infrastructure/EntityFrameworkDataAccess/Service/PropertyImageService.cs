namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Weelo.Application.Services;
    using Weelo.Domain;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache;    

    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IPropertyImageCacheService _propertyImageCacheService;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyImageService(IPropertyImageRepository propertyImageRepository, IPropertyImageCacheService propertyImageCacheService, IUnitOfWork unitOfWork) {
            _propertyImageRepository = propertyImageRepository;
            _propertyImageCacheService = propertyImageCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PropertyImageEntity> GetAsync(int id)
        {
            return await _propertyImageRepository.GetAsync(id);
        }

        public async Task<List<PropertyImageEntity>> GetAllAsync()
        {
            var cached = await _propertyImageCacheService.GetAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");

            if (cached != null)
            {
                return cached;
            }
            else
            {
                var propertyImages = await _propertyImageRepository.GetAllAsync();
                await _propertyImageCacheService.SetAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All", propertyImages);
                return propertyImages;
            }
        }

        public async Task<IEnumerable<PropertyImageEntity>> FindAsync(Expression<Func<PropertyImageEntity, bool>> predicate)
        {
             return await _propertyImageRepository.FindAsync(predicate);
        }

        public async Task<PropertyImageEntity> SingleOrDefaultAsync(Expression<Func<PropertyImageEntity, bool>> predicate)
        {
            return await _propertyImageRepository.SingleOrDefaultAsync(predicate);
        }

        public async Task<PropertyImageEntity> AddOrUpdateAsync(PropertyImageEntity entity)
        {
           if (entity.Id > 0)
            {
                entity = await _propertyImageRepository.UpdateAsync(entity);                
            }
            else
            {
                entity = await _propertyImageRepository.AddAsync(entity);
            }
            
            await _unitOfWork.SaveChangesAsync();

            await _propertyImageCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<PropertyImageEntity> entities)
        {
            await _propertyImageRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyImageCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");
        }

        public async Task<bool> RemoveAsync(PropertyImageEntity entity)
        {
            var result = await _propertyImageRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _propertyImageCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");

            return result;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<PropertyImageEntity> entities)
        {
            var result = await _propertyImageRepository.RemoveRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyImageCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");
            
            return result;
        }
        
        public async Task RemoveByPropertyIdAsync(long propertyId)
        {
            await _propertyImageRepository.RemoveByPropertyIdAsync(propertyId);
            await _unitOfWork.SaveChangesAsync();

            await _propertyImageCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY_IMAGE}:All");
        }
    }
}