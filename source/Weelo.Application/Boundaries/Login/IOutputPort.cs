namespace Weelo.Application.Boundaries.Login
{
    public interface IOutputPort : IErrorHandler
    {
        void NotFound(string message);
        void Default(LoginOutput loginOutput, string message);
    }
}