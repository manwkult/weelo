namespace Weelo.Application.Boundaries.Owner.CreateOwner
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(CreateOwnerOutput output, string message);
    }
}