namespace Weelo.Application.Boundaries.Owner.CreateOwner
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(CreateOwnerInput input);
    }
}