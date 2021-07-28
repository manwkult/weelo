namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
    using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public interface IPropertyImageRepository : IRepository<PropertyImageEntity>
    {
        Task RemoveByPropertyIdAsync(long propertyId);
    }
}