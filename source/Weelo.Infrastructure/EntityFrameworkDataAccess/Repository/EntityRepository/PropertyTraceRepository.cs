namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class PropertyTraceRepository : Repository<PropertyTraceEntity>, IPropertyTraceRepository
    {
        public PropertyTraceRepository(WeeloContext context) : base(context)
        { }
    }
}