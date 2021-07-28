namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WeeloContext _context;

        public Repository(WeeloContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => {
                return _context.Set<TEntity>().Where(predicate);
            });
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _context.Set<TEntity>().Update(entity);
                return entity;
            });
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            });
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            return await Task.Run(() =>
            {
                _context.Set<TEntity>().RemoveRange(entities);
                return true;
            });
        }
    }
}