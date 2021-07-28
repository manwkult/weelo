namespace Weelo.Application.Boundaries.Login
{
    using System.Threading.Tasks;
    
    public interface IUseCase
    {
        Task Execute(LoginInput input);
    }
}