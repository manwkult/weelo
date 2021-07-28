namespace Weelo.Application.Boundaries.PropertyImage.AddPropertyImage
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(AddPropertyImageInput input);
    }
}