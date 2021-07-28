namespace Weelo.Application.Boundaries.Property.DeleteProperty
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(DeletePropertyOutput output, string message);
    }
}