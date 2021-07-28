namespace Weelo.Application.Gateway
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Weelo.Domain.Models;

    public interface IOwnerGateway
    {
        Task<List<Owner>> GetAllAsync();
        Task<Owner> AddOrUpdateAsync(Owner property);
    }
}