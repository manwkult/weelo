namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public class OwnerRepository : Repository<OwnerEntity>, IOwnerRepository
    {
        public OwnerRepository(WeeloContext context) : base(context)
        { }
    }
}