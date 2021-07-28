namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;

    public interface IPropertyRepository : IRepository<PropertyEntity>
    {
        Task<List<PropertyEntity>> GetAllWhitOwnerAsync();
        Task<bool> ChangePriceAsync(long id, decimal price);
    }
}