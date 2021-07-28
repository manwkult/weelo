namespace Weelo.Application.Boundaries.Property.DeleteProperty
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(DeletePropertyInput input);
    }
}