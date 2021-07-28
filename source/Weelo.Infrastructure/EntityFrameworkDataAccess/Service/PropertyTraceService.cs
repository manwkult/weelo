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

    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IPropertyTraceCacheService _propertyTraceCacheService;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyTraceService(IPropertyTraceRepository propertyTraceRepository, IPropertyTraceCacheService propertyTraceCacheService, IUnitOfWork unitOfWork) {
            _propertyTraceRepository = propertyTraceRepository;
            _propertyTraceCacheService = propertyTraceCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PropertyTraceEntity> GetAsync(int id)
        {
            return await _propertyTraceRepository.GetAsync(id);
        }

        public async Task<List<PropertyTraceEntity>> GetAllAsync()
        {
            var cached = await _propertyTraceCacheService.GetAsync($"{Constants.CACHE_KEY_OWNER}:All");

            if (cached != null)
            {
                return cached;
            }
            else
            {
                var propertyTraces = await _propertyTraceRepository.GetAllAsync();
                await _propertyTraceCacheService.SetAsync($"{Constants.CACHE_KEY_OWNER}:All", propertyTraces);
                return propertyTraces;
            }
        }

        public async Task<IEnumerable<PropertyTraceEntity>> FindAsync(Expression<Func<PropertyTraceEntity, bool>> predicate)
        {
             return await _propertyTraceRepository.FindAsync(predicate);
        }

        public async Task<PropertyTraceEntity> SingleOrDefaultAsync(Expression<Func<PropertyTraceEntity, bool>> predicate)
        {
            return await _propertyTraceRepository.SingleOrDefaultAsync(predicate);
        }

        public async Task<PropertyTraceEntity> AddOrUpdateAsync(PropertyTraceEntity entity)
        {
           if (entity.Id > 0)
            {
                entity = await _propertyTraceRepository.UpdateAsync(entity);                
            }
            else
            {
                entity = await _propertyTraceRepository.AddAsync(entity);
            }
            
            await _unitOfWork.SaveChangesAsync();

            await _propertyTraceCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<PropertyTraceEntity> entities)
        {
            await _propertyTraceRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyTraceCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
        }

        public async Task<bool> RemoveAsync(PropertyTraceEntity entity)
        {
            var result = await _propertyTraceRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _propertyTraceCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");

            return result;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<PropertyTraceEntity> entities)
        {
            var result = await _propertyTraceRepository.RemoveRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _propertyTraceCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
            
            return result;
        }
    }
}