namespace Weelo.Application.Boundaries.Property.CreateProperty
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(CreatePropertyInput input);
    }
}