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

    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IOwnerCacheService _ownerCacheService;
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IOwnerRepository ownerRepository, IOwnerCacheService ownerCacheService, IUnitOfWork unitOfWork) {
            _ownerRepository = ownerRepository;
            _ownerCacheService = ownerCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<OwnerEntity> GetAsync(int id)
        {
            return await _ownerRepository.GetAsync(id);
        }

        public async Task<List<OwnerEntity>> GetAllAsync()
        {
            var cached = await _ownerCacheService.GetAsync($"{Constants.CACHE_KEY_OWNER}:All");

            if (cached != null)
            {
                return cached;
            }
            else
            {
                var owners = await _ownerRepository.GetAllAsync();
                await _ownerCacheService.SetAsync($"{Constants.CACHE_KEY_OWNER}:All", owners);
                return owners;
            }
        }

        public async Task<IEnumerable<OwnerEntity>> FindAsync(Expression<Func<OwnerEntity, bool>> predicate)
        {
             return await _ownerRepository.FindAsync(predicate);
        }

        public async Task<OwnerEntity> SingleOrDefaultAsync(Expression<Func<OwnerEntity, bool>> predicate)
        {
            return await _ownerRepository.SingleOrDefaultAsync(predicate);
        }

        public async Task<OwnerEntity> AddOrUpdateAsync(OwnerEntity entity)
        {
           if (entity.Id > 0)
            {
                entity = await _ownerRepository.UpdateAsync(entity);                
            }
            else
            {
                entity = await _ownerRepository.AddAsync(entity);
            }
            
            await _unitOfWork.SaveChangesAsync();

            await _ownerCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<OwnerEntity> entities)
        {
            await _ownerRepository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _ownerCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
        }

        public async Task<bool> RemoveAsync(OwnerEntity entity)
        {
            var result = await _ownerRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _ownerCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");

            return result;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<OwnerEntity> entities)
        {
            var result = await _ownerRepository.RemoveRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();

            await _ownerCacheService.DeleteAsync($"{Constants.CACHE_KEY_OWNER}:All");
            
            return result;
        }
    }
}