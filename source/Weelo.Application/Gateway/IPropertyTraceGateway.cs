namespace Weelo.Application.Gateway
{
    using System.Threading.Tasks;
    using Weelo.Domain.Models;

    public interface IPropertyTraceGateway
    {
        Task<PropertyTrace> AddOrUpdateAsync(PropertyTrace propertyTrace);
    }
}