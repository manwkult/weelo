namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
  using System.Linq;
  using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class PropertyImageRepository : Repository<PropertyImageEntity>, IPropertyImageRepository
    {
        private readonly WeeloContext _context;

        public PropertyImageRepository(WeeloContext context) : base(context)
        {
            _context = context;
        }

        public async Task RemoveByPropertyIdAsync(long propertyId) {
           await Task.Run(() => {
                _context.Set<PropertyImageEntity>().RemoveRange(
                    _context.Set<PropertyImageEntity>().Where(pi => pi.PropertyId == propertyId)
                );
           });
        }
    }
}