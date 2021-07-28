namespace Weelo.Application.Boundaries.Property.ChangePropertyPrice
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(ChangePropertyPriceInput input);
    }
}