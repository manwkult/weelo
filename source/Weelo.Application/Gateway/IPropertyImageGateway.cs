namespace Weelo.Application.Gateway
{
    using System.Threading.Tasks;
    using Weelo.Domain.Models;

    public interface IPropertyImageGateway
    {
        Task<PropertyImage> AddOrUpdateAsync(PropertyImage propertyImage);
    }
}