namespace Weelo.Application.Boundaries.Owner.GetAllOwners
{
    public interface IOutputPort : IErrorHandler
    {
        void NotFound(string message);
        void Default(GetAllOwnersOutput output, string message);
    }
}