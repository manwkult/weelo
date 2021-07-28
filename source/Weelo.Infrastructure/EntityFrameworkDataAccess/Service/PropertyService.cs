namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Weelo.Application.Services;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository;
    using Weelo.Domain;

    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyCacheService _propertyCacheService;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyService(IPropertyRepository propertyRepository, IPropertyCacheService propertyCacheService, IUnitOfWork unitOfWork) {
            _propertyRepository = propertyRepository;
            _propertyCacheService = propertyCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PropertyEntity> GetAsync(int id)
        {
            return await _propertyRepository.GetAsync(id);
        }

        public async Task<List<PropertyEntity>> GetAllAsync()
        {
            var cached = await _propertyCacheService.GetAsync($"{Constants.CACHE_KEY_PROPERTY}:All");

            if (cached != null)
            {
                return cached;
            }
            else
            {
                var properties = await _propertyRepository.GetAllAsync();
                await _propertyCacheService.SetAsync($"{Constants.CACHE_KEY_PROPERTY}:All", properties);
                return properties;
            }
        }

        public async Task<List<PropertyEntity>> GetAllWhitOwnerAsync()
        {
            var cached = await _propertyCacheService.GetAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");

            if (cached != null)
            {
                return cached;
            }
            else
            {
                var properties = await _propertyRepository.GetAllWhitOwnerAsync();
                await _propertyCacheService.SetAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner", properties);
                return properties;
            }
        }

        public async Task<IEnumerable<PropertyEntity>> FindAsync(Expression<Func<PropertyEntity, bool>> predicate)
        {
             return await _propertyRepository.FindAsync(predicate);
        }

        public async Task<PropertyEntity> SingleOrDefaultAsync(Expression<Func<PropertyEntity, bool>> predicate)
        {
            return await _propertyRepository.SingleOrDefaultAsync(predicate);
        }

        public async Task<PropertyEntity> AddOrUpdateAsync(PropertyEntity entity)
        {
            if (entity.Id > 0)
            {
                entity = await _propertyRepository.UpdateAsync(entity);                
            }
            else
            {
                entity = await _propertyRepository.AddAsync(entity);
            }
            
            await _unitOfWork.SaveChangesAsync();

            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:All");
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");

            return entity;
        }

        public async Task<bool> ChangePriceAsync(long id, decimal price)
        {
            var result = await _propertyRepository.ChangePriceAsync(id, price);
            await _unitOfWork.SaveChangesAsync();
            
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:All");
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");

            return result;
        }

        public async Task AddRangeAsync(IEnumerable<PropertyEntity> entities)
        {
            await _propertyRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");
        }

        public async Task<bool> RemoveAsync(PropertyEntity entity)
        {
            var result = await _propertyRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");

            return result;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<PropertyEntity> entities)
        {
            var result = await _propertyRepository.RemoveRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
            await _propertyCacheService.DeleteAsync($"{Constants.CACHE_KEY_PROPERTY}:WhitOwner");
            
            return result;
        }
    }
}