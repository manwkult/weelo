namespace Weelo.Application.Gateway
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Weelo.Domain.Models;

    public interface IPropertyGateway
    {
        Task<List<Property>> GetAllAsync();
        Task<Property> AddOrUpdateAsync(Property property);
        Task<bool> ChangePriceAsync(PropertyPrice propertyPrice);
        Task<bool> DeleteAsync(long id);
    }
}