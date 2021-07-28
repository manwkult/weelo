namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Service.Cache
{
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ICacheService<T> where T : class
    {
        Task<List<T>> GetAsync(string key);
        Task SetAsync(string key, List<T> value);
        Task DeleteAsync(string key);
    }
}