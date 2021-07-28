namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class PropertyRepository : Repository<PropertyEntity>, IPropertyRepository
    {
        private readonly WeeloContext _context;
        
        public PropertyRepository(WeeloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PropertyEntity>> GetAllWhitOwnerAsync()
        {
            return await _context.Set<PropertyEntity>()
                .Include(p => p.Owner)
                .Include(p => p.PropertyImages)
                .Include(p => p.PropertyTraces)
                .ToListAsync();
        }

        public async Task<bool> ChangePriceAsync(long id, decimal price)
        {
            return await Task.Run(() => {
                _context
                    .Set<PropertyEntity>()
                    .Attach(new PropertyEntity() { Id = id, Price = price })
                    .Property(x => x.Price).IsModified = true;

                return true;
            });
        }
    }
}