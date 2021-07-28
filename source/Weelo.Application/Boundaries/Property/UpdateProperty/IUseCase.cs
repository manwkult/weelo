namespace Weelo.Application.Boundaries.Property.UpdateProperty
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(UpdatePropertyInput input);
    }
}